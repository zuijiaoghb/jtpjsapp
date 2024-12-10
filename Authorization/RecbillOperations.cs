using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace jtpjsapp.Authorization
{
    public static class RecbillOperations
    {
        public static OperationAuthorizationRequirement Create =   
          new OperationAuthorizationRequirement {Name=Recbills.CreateOperationName};
        public static OperationAuthorizationRequirement Read = 
          new OperationAuthorizationRequirement {Name=Recbills.ReadOperationName};  
        public static OperationAuthorizationRequirement Update = 
          new OperationAuthorizationRequirement {Name=Recbills.UpdateOperationName}; 
        public static OperationAuthorizationRequirement Delete = 
          new OperationAuthorizationRequirement {Name=Recbills.DeleteOperationName};
        public static OperationAuthorizationRequirement Approve = 
          new OperationAuthorizationRequirement {Name=Recbills.ApproveOperationName};
        public static OperationAuthorizationRequirement Reject = 
          new OperationAuthorizationRequirement {Name=Recbills.RejectOperationName};
	public static OperationAuthorizationRequirement Split =
          new OperationAuthorizationRequirement {Name=Recbills.SplitOperationName};
    }

    public class Recbills
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";
	public static readonly string SplitOperationName = "Split";

        public static readonly string RecbillAdministratorsRole = 
                                                              "RecbillAdministrators";
        public static readonly string RecbillManagersRole = "RecbillManagers";
    }
}
