using Dapper;
using JWTAuthDemo.Models;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
  
 namespace Repository
 {
     public interface IJWTAuthManager
     {
        Response<string> GenerateJWT(User user);
        Response<T> Execute_Command<T>(string query, DynamicParameters sp_params);
        Response<List<T>> getUserList<T>();
     }
 } 