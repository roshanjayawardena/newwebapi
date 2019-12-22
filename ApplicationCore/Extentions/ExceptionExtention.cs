using ApplicationCore.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ApplicationCore.Extentions
{
    public static class ExceptionExtention
    {

        public static Exception HandleException(this Exception ex, object requestObject)
        {
            var stringObject = string.Empty;
            if (!requestObject.IsNull())
            {
                try
                {
                    stringObject = requestObject.ToJsonString();
                }
                catch (Exception e)
                {
                    stringObject = "";
                }
            }
            throw HandleException(ex, stringObject);
        }

        public static Exception HandleException(this Exception ex, string requestObject = "")
        {
            ex = ex.GetBaseException();
            if (ex is SqlException)
            {
                var e = ex as SqlException;
                switch (e.Number)
                {
                    case 2627:
                    case 2601:
                        return new PrimaryKeyViolationException();
                    case 547:
                        return new ForeignKeyViolationException();
                    default:
                        if (new List<int>() { 2601, 1062 }.Contains(e.Number))
                        {
                            return new PrimaryKeyViolationException();
                        }

                        break;
                }
                return ex;
            }
            else if (ex is DbUpdateException)
            {
                return new EntityValidationException(ex.GetBaseException().Message);
            }
            else if (ex is MySqlException)
            {
                return ex;
            }
            else if (ex.GetType().FullName == "MySql.Data.MySqlClient.MySqlException")
            {
                // fk
                if (ex.Message.Contains("foreign key constraint fails"))
                {
                    return new MySqlException("There are some items depend on this");
                }
                //uk           
                else if (ex.Message.Contains("Duplicate entry"))
                {
                    return new MySqlException(ex.Message.Substring(0, ex.Message.IndexOf("for")));
                }
                return new MySqlException(ex.Message);
            }
            else if (ex is ArgumentNullException)
            {
                return new RecordNotFoundException();
            }
            else if (ex is ForbiddenException ||
                     ex is UnAuthorizedException ||
                     ex is RecordNotFoundException ||
                     ex is NullObjectException ||
                     ex is BlobExteption ||
                     ex is InvalidDomainCastException ||
                     ex is EntityValidationException ||
                     ex is PrimaryKeyViolationException ||
                     ex is OperationFailedException ||
                     ex is ForeignKeyViolationException ||
                     ex is PermissionException ||
                     ex is SameNameException ||
                     ex is InvalidProcessException ||
                     ex is InvalidDataException ||
                     ex is UserSecurityException ||
                     ex is DataInconsistencyException ||
                     ex is DataInconsistencyClientException ||
                     ex is PaymentGatewayException ||
                     ex is EatException
                     )
            {
                throw ex;
            }
            else
            {
                return new InternalSrverErrorException(ex, requestObject);
            }
        }

    }
}
