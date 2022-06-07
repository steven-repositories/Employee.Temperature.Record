using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Builders;
using Employee.Temperature.Record.Api.Entities;
using Employee.Temperature.Record.Api.Entity;
using Employee.Temperature.Record.Api.Enums;
using Employee.Temperature.Record.Api.Models;
using Employee.Temperature.Record.Api.Substructures;
using Employee.Temperature.Record.Api.Utilities;
using System;
using System.Linq;
using System.Reflection;

namespace Employee.Temperature.Record.Api.Services {
    internal class RestService : RestBase, ICommunicationInterface {
        public RestService(AppDbContext dbContext) : base(dbContext) { }

        #region Internal Methods
        private RecordResponse SearchFilter(SearchFilter filter) {
            try {
                var query = GetQueryable();

                if (filter.Id != null 
                    && filter.Id.Count() > 0) {
                    query = query
                        .Where(employee => filter.Id.Contains(employee.Id));
                }

                if (filter.FirstName != null
                    && filter.FirstName.Count() > 0) {
                    query = query
                        .Where(employee => filter.FirstName.Contains(employee.Person.FirstName));
                }

                if (filter.LastName != null
                    && filter.LastName.Count() > 0) {
                    query = query
                        .Where(employee => filter.LastName.Contains(employee.Person.LastName));
                }

                if (filter.CreatedDateTimeFirst != default(DateTime)
                    && filter.CreatedDateTimeLast != default(DateTime)) {
                    query = query
                        .Where(employee => employee.CreatedDateTime >= filter.CreatedDateTimeFirst
                            && employee.CreatedDateTime <= filter.CreatedDateTimeLast);
                }

                if (filter.Temperature != null
                    && filter.Temperature.Count() > 0) {
                    query = query
                        .Where(employee => filter.Temperature.Contains(employee.Temperature.Temperature));
                }

                return new RecordResponse(query.ToList());
            }
            catch (Exception e) {
                throw new ApiException(e.Message);
            }
        }
        #endregion

        public IRecordResponse Get<T>(T builder) where T : Builder<T> {
            try {
                var query = GetQueryable();

                if (builder is ManageBuilder manageBuilder) {
                    if (builder.EmployeeId != default(int)) {
                        query = query
                            .Where(employee => employee.Id == builder.EmployeeId);
                    }

                    switch (manageBuilder.PullType) {
                        case PullTypes.Single:
                            return new RecordResponse(query.FirstOrDefault());
                        case PullTypes.All:
                            return new RecordResponse(query.ToList());
                        default:
                            throw new ApiException("Pull type is not expected.");
                    }
                }

                throw new ApiException("API Method is not reachable.");
            }
            catch (Exception e) {
                throw new ApiException(e.Message);
            }
        }

        public IRecordResponse Post<T>(T builder) where T : Builder<T> {
            try {
                var isFilterSearch = (builder as AuthBuilder)
                    .AuthType is AuthTypes.Filter;

                if (!isFilterSearch) {
                    var person = new Person() {
                        FirstName = (builder as AuthBuilder)
                                .EmployeeRecord
                                .FirstName,
                        LastName = (builder as AuthBuilder)
                                .EmployeeRecord
                                .LastName
                    };

                    var temperature = new Inversion() {
                        Temperature = (builder as AuthBuilder)
                            .EmployeeRecord
                            .Temperature
                    };

                    _dbContext
                        .Set<Laborer>()
                        .Add(new Laborer() {
                            Person = person,
                            Temperature = temperature
                        });

                    _dbContext
                        .SaveChanges();

                    return new RecordResponse(new {
                        status = "Recorded!"
                    });
                }
                else {
                    return SearchFilter((builder as AuthBuilder).SearchFilter);
                }
            }
            catch (Exception e) {
                throw new ApiException(e.Message);
            }
        }

        public IRecordResponse Put<T>(T builder) where T : Builder<T> {
            try {
                var employee = GetQueryable()
                    .Where(employee => employee.Id == builder.EmployeeId)
                    .FirstOrDefault();

                if (employee == null) {
                    throw new ApiException("There is no recorded employee with {0} id."
                        .FormatWith(builder.EmployeeId));
                }

                var employeeRuntimeProps = employee
                    .GetType()
                    .GetRuntimeProperties();

                // Used reflection here to identify each column
                // if there should be changes need to be made
                foreach (var prop in employeeRuntimeProps) {
                    var propValue = prop
                        .GetValue(employee);

                    var propType = prop
                        .PropertyType;

                    // Open for extension, closed for modification
                    // can be extended only if there will be new props
                    // in entity that the datatype is not an object
                    if (propType.IsClass) {
                        var subPropRuntimeProps = propType
                            .GetRuntimeProperties();

                        foreach (var subProp in subPropRuntimeProps) {
                            var canSetMethod = subProp
                                .SetMethod == null;

                            var subPropValue = !canSetMethod
                                ? subProp
                                    .GetValue(propValue)
                                : default;

                            if (subPropValue != null) {
                                var recordStored = (object)(builder as AuthBuilder)
                                    .EmployeeRecord[subProp.Name];

                                if (!recordStored.IsNullOrEmpty()
                                    && subPropValue != recordStored) {
                                    subProp.SetValue(propValue, recordStored);
                                }
                            }
                        }
                    }
                }

                employee.ModifiedDateTime = DateTime.Now;
                employee.Person.ModifiedDateTime = DateTime.Now;
                employee.Temperature.ModifiedDateTime = DateTime.Now;

                _dbContext
                    .SaveChanges();

                return new RecordResponse(new {
                    status = "Updated!"
                });
            }
            catch (Exception e) {
                throw new ApiException(e.Message);
            }
        }

        public IRecordResponse Delete<T>(T builder) where T : Builder<T> {
            throw new NotImplementedException();
        }
    }
}
