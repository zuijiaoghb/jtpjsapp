using System.Threading.Tasks;
using jtpjsapp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace jtpjsapp.Authorization
{
    public class RecbillAdministratorsAuthorizationHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, RecBillModel>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement, 
                                     RecBillModel resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Recbills.RecbillAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
