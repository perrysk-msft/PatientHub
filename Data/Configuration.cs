﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PatientHubData
{
    public static class Configuration
    {
        public static string scoringURL = ConfigurationManager.AppSettings["scoringURL"];
        public static string authKey = ConfigurationManager.AppSettings["authKey"];

        public static string connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        public static string spGetPatients = ConfigurationManager.AppSettings["spGetPatients"];
        public static string spGetModels = ConfigurationManager.AppSettings["spGetModels"];        
        public static string spGetDMPRW30Days_LocalExplanation = ConfigurationManager.AppSettings["spGetDMPRW30Days_LocalExplanation"];
        public static string spGet_DMPRW30Days_SingleInference = ConfigurationManager.AppSettings["spGet_DMPRW30Days_SingleInference"];
        public static int commandTimeout = int.Parse(ConfigurationManager.AppSettings["commandTimeout"]);
    }
}