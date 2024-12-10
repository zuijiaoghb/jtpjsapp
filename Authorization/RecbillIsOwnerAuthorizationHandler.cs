using jtpjsapp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace jtpjsapp.Authorization
{
    public class RecbillIsOwnerAuthorizationHandler
                : AuthorizationHandler<OperationAuthorizationRequirement, RecBillModel>
    {
       // UserManager<IdentityUser> _userManager;
       UserManager<ApplicationUser> _userManager;

        public RecbillIsOwnerAuthorizationHandler(UserManager<ApplicationUser> 
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   RecBillModel resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for CRUD permission, return.

            if (requirement.Name != Recbills.CreateOperationName &&
                requirement.Name != Recbills.ReadOperationName   &&
                requirement.Name != Recbills.UpdateOperationName &&
                requirement.Name != Recbills.DeleteOperationName &&
		requirement.Name != Recbills.SplitOperationName
		)
            {
                return Task.CompletedTask;
            }

            if (resource.OwnerID == _userManager.GetUserId(context.User) || (resource.Status==RecbillStatus.Approved && requirement.Name==Recbills.ReadOperationName ) )
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
