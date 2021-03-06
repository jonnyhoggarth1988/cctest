﻿using System.Linq;
using Dapper;
using ui;
using Xunit;

namespace unit_tests
{
    public class ExampleTest
    {
        [Fact]
        public void ShouldPass()
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();

            var sql = "SELECT 1";
            var expectedResult = 1;
            var actualResult = dbConnection.QueryFirst<int>(sql);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void NumberOfBranchesFetchedCorrectly()
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();
            var sql = "SELECT COUNT(*) FROM branches";
            var expectedResult = dbConnection.QueryFirst<int>(sql);
            dbConnection.Close();

            var db = new Database();
            var actualResult = db.FetchAllBranches();

            Assert.Equal(expectedResult, actualResult.Count());
        }
    }
}