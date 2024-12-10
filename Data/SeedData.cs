using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using jtpjsapp.Authorization;

namespace jtpjsapp.Data;

public class SeedData {
	
public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
{
    using (var context = new ApplicationDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
    {
        // For sample purposes seed both with the same password.
        // Password is set with the following:
        // dotnet user-secrets set SeedUserPW <pw>
        // The admin user can do anything

        var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@263.com");
        await EnsureRole(serviceProvider, adminID, Recbills.RecbillAdministratorsRole);

        // allowed user can create and edit contacts that they create
        var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@263.com");
        await EnsureRole(serviceProvider, managerID, Recbills.RecbillManagersRole);

        SeedDB(context, adminID);
    }
}

private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
{
   // var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

    var user = await userManager.FindByNameAsync(UserName);
    if (user == null)
    {
        user = new ApplicationUser
        {
            UserName = UserName,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user, testUserPw);
    }

    if (user == null)
    {
        throw new Exception("密码强度太弱!");
    }

    return user.Id;
}

private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string uid, string role)
{
    var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

    if (roleManager == null)
    {
        throw new Exception("roleManager null");
    }

    IdentityResult IR;
    if (!await roleManager.RoleExistsAsync(role))
    {
        IR = await roleManager.CreateAsync(new IdentityRole(role));
    }

    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

    //if (userManager == null)
    //{
    //    throw new Exception("userManager is null");
    //}

    var user = await userManager.FindByIdAsync(uid);

    if (user == null)
    {
        throw new Exception("The testUserPw password was probably not strong enough!");
    }

    IR = await userManager.AddToRoleAsync(user, role);

    return IR;
}	

public static void SeedDB(ApplicationDbContext context, string adminID)
{
    if (context.RecBillModels.Any())
    {
        return;   // DB has been seeded
    }

    context.RecBillModels.AddRange(
        new RecBillModel
        {
            RecDate = DateTime.Now,
            RecVoucher = "2024-06-08#",
            EntryName = "江西江特电机有限公司",
            RecBillCategory = "电子银行承兑汇票",
            FrontRela = "合并范围内关联方",
            NewGeneration = "是",
            TicketNumber = "531665300002620240607001228939",
            SubTicketNumber = "000002576478000023235060",
			IssuingUnit = "中冶赛迪工程技术股份有限公司",
			AcceptorName = "浙商银行股份有限公司重庆分行",
			Is69 = "是",
			AcceptAmount = Convert.ToDecimal(206585.83),
			TicketIssueDate = DateTime.Now,
			DueDate = DateTime.Now,
			Selected = false,
			OwnerID = adminID,
			Status = RecbillStatus.Approved,
			Company = RecbillCompany.江特电机,
			Endorser = "",
			Balance = Convert.ToDecimal(206585.83),
			TransferAmount = 0,
			AddTime = DateTime.Now,
			ModifyTime = null,
			IsMotherTicket = "是"
        }
	);

}	

}
