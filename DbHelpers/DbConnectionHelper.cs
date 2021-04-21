using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessArchitecture.DbHelpers
{
	public static class DbConnectionHelper
	{
		public static IServiceCollection AddDbConnection([NotNullAttribute] this IServiceCollection serviceCollection, 
			DbProviderFactory dbFactory, string connectionString)
		{
			if (dbFactory == null || string.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException("Can not create connection from invalid arguments");
			IDbConnection connection = dbFactory.CreateConnection();
			connection.ConnectionString = connectionString;
			return serviceCollection.AddScoped<IDbConnection>(dbConnection => connection);
		}
	}
}
