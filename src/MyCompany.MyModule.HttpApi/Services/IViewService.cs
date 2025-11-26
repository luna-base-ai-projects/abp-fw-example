
using System;
using Microsoft.AspNetCore.Mvc;

namespace MyCompany.MyModule.Services;

public interface IViewService
{
    IActionResult GetLoginView();
    IActionResult GetLoginSuccessView(string username, DateTime loginTime);
}
