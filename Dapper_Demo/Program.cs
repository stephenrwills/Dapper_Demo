﻿using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper_Demo;
using Dapper;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

repo.InsertDepartment("Test1");
repo.UpdateDepartment(15, "TESTUPDATED");



var departments = repo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
}
