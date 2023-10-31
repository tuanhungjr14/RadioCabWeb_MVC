// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioCabs.Utility;

namespace RadioCab.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public CompanyInputModel CInput { get; set; }
        public DriverInputModel DInput { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
        public class DriverInputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "Driver Address is required")]
            public string DriverAddress { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string DriverName { get; set; }

            [Required(ErrorMessage = "City is required")]
            public string City { get; set; }

            [Required(ErrorMessage = "Mobile number is required")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid mobile number")]
            public string Mobile { get; set; }

            [Required(ErrorMessage = "Telephone number is required")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid telephone number")]
            public string Telephone { get; set; }

            

            [Required(ErrorMessage = "Experience is required")]
            public int Experience { get; set; }

            [Required(ErrorMessage = "Driver Description is required")]
            public string DriverDescripts { get; set; }
        }
        public class CompanyInputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Company Name")]
            [Required(ErrorMessage = "Company Name is required")]
            public string CompanyName { get; set; }

            [Display(Name = "Contact Person")]
            [Required(ErrorMessage = "Contact person is required")]
            public string ContactPerson { get; set; }

            [Display(Name = "Designation")]
            [Required(ErrorMessage = "Designation is required")]
            public string DesignNation { get; set; }

            [Display(Name = "Address")]
            [Required(ErrorMessage = "Address is required")]
            public string CabAddress { get; set; }


            [Display(Name = "Telephone")]
            [Required(ErrorMessage = "Telephone is required")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid telephone number")]
            public string Telephone { get; set; }

            [Display(Name = "Fax Number")]
            [Required(ErrorMessage = "Fax Number is required")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid fax number")]
            public string FaxNumber { get; set; }

            [Display(Name = "Membership Type")]
            public string MembershipType { get; set; }

        }

        


        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            CInput = new CompanyInputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
{
    var user = await _userManager.GetUserAsync(User);
    if (user == null)
    {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
    }

    if (!ModelState.IsValid)
    {
        // If the model state is not valid, reload the data and return the page
        await LoadAsync(user);
        return Page();
    }

    // Update the user's phone number
    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
    if (CInput.PhoneNumber != phoneNumber)
    {
        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, CInput.PhoneNumber);
        if (!setPhoneResult.Succeeded)
        {
            StatusMessage = "Unexpected error when trying to set phone number.";
            return RedirectToPage();
        }
    }

    
    await _signInManager.RefreshSignInAsync(user);
    StatusMessage = "Your profile has been updated";
    return RedirectToPage();
}

    }
}
