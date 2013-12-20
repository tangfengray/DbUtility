﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.Data.Queries
{
  /// <summary>
  /// 数据表表达式
  /// </summary>
  public class TableQuery : DbQuery
  {

    private string _tableName;

    /// <summary>
    /// 构建数据表表达式
    /// </summary>
    /// <param name="tableName">表名</param>
    public TableQuery( IDbExecutor<StoredProcedureQuery> executor, string tableName )
    {
      _tableName = tableName;
    }

    private string[] _fields = null;

    /// <summary>
    /// 设置要获取的字段列表
    /// </summary>
    /// <param name="fields">要获取的字段列表</param>
    /// <returns>返回数据表表达式自身</returns>
    public TableQuery Fields( params string[] fields )
    {
      _fields = fields;
      return this;
    }

    /// <summary>
    /// 设置要筛选的条件
    /// </summary>
    /// <param name="whereClause">要设置的筛选条件模版</param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public TableQuery Where( string whereClause, params object[] parameters )
    {
      throw new NotImplementedException();
    }




    protected IDbExecutor<TableQuery> DbExecutor
    {
      get;
      private set;
    }


    public override IDbExecuteContext Execute()
    {
      return DbExecutor.Execute( this );
    }

    public override Task<IDbExecuteContext> ExecuteAsync()
    {
      var asyncExecutor = DbExecutor as IAsyncDbExecutor<TableQuery>;
      if ( asyncExecutor != null )
        return asyncExecutor.ExecuteAsync( this );

      return new Task<IDbExecuteContext>( Execute );
    }
  }

  public class SelectClause
  {
    public SelectClause AddField( string fieldExpression, string fieldName = null )
    {
      throw new NotImplementedException();
    }


  }




}
