using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SQLTransactionIsolationLevel.Models;

namespace SQLTransactionIsolationLevel;

public class IsolationManager
{
    private const string ConnectionStringName = "IsolationDatabase";

    private readonly SqlConnection _connection;
    private SqlTransaction _sqlTransaction;
    private readonly IsolationLevel _isolationLevel;

    private static readonly Random Random = new Random();

    public IsolationManager(IsolationLevel isolationLevel)
    {
        _isolationLevel = isolationLevel;
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
        _connection.Open();

        _sqlTransaction = _connection.BeginTransaction(isolationLevel);
    }

    public async Task<List<Member>> FetchMembers()
    {
        return await Task.Run(() =>
        {
            var memberList = new List<Member>();
            try
            {
                var selectCommand = CreateTransactionCommand("Select * From Members");

                using (var dataReader = selectCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var member = new Member
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                Surname = dataReader["Surname"].ToString(),
                                Age = int.Parse(dataReader["Age"].ToString()),
                                Status = int.Parse(dataReader["Status"].ToString())
                            };
                            memberList.Add(member);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return memberList;
        });

    }

    public async Task<List<Member>> FetchMembersWithoutFirst()
    {
        return await Task.Run(() =>
        {
            var memberList = new List<Member>();
            try
            {
                var selectCommand = CreateTransactionCommand("Select * From Members Where Id != 1");

                using (var dataReader = selectCommand.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var member = new Member
                            {
                                Id = int.Parse(dataReader["Id"].ToString()),
                                Name = dataReader["Name"].ToString(),
                                Surname = dataReader["Surname"].ToString(),
                                Age = int.Parse(dataReader["Age"].ToString()),
                                Status = int.Parse(dataReader["Status"].ToString())
                            };
                            memberList.Add(member);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return memberList;
        });

    }

    public async Task InsertMember()
    {
        await Task.Run(() =>
        {
            try
            {
                var insertCommand = CreateTransactionCommand("Insert Into Members(Name,Surname,Age,Status) Values(@Name,@Surname,@Age,@Status)");
                insertCommand.Parameters.AddWithValue("@Name", RandomString(15));
                insertCommand.Parameters.AddWithValue("@Surname", RandomString(15));
                insertCommand.Parameters.AddWithValue("@Age", Random.Next(25));
                insertCommand.Parameters.AddWithValue("@Status", Random.Next(5));
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        });
    }

    public async Task UpdateMember()
    {
        await Task.Run(() =>
        {
            try
            {
                var insertCommand = CreateTransactionCommand("Update Members Set Age = @Age Where Id = 1");
                insertCommand.Parameters.AddWithValue("@Age", Random.Next(25));
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        });
    }

    public async Task Commit()
    {
        await Task.Run(() =>
        {
            try
            {
                _sqlTransaction.Commit();
                _sqlTransaction = _connection.BeginTransaction(_isolationLevel);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        });
    }

    public async Task RollBack()
    {
        await Task.Run(() =>
        {
            try
            {
                _sqlTransaction.Rollback();
                _sqlTransaction = _connection.BeginTransaction(_isolationLevel);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        });
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    private SqlCommand CreateTransactionCommand(string command)
    {
        var selectCommand = _connection.CreateCommand();
        selectCommand.CommandText = command;
        selectCommand.Connection = _connection;
        selectCommand.Transaction = _sqlTransaction;
        return selectCommand;
    }
}