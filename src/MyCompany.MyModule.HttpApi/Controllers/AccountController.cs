
using System;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using MyCompany.MyModule.Services;

namespace MyCompany.MyModule.Controllers;

[Route("Account")]
public class AccountController : AbpController
{
    private readonly IViewService _viewService;

    public AccountController(IViewService viewService)
    {
        _viewService = viewService;
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return _viewService.GetLoginView();
    }

    [HttpPost("Login")]
    public IActionResult Login(string username, string password)
    {
        // Simple demo authentication - in real app, use proper authentication
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            return _viewService.GetLoginSuccessView(username, DateTime.Now);
        }

        // If authentication fails, redirect back to login with error
        return RedirectToAction("Login");
    }
}
