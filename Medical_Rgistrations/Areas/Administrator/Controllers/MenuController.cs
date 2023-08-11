using DBAccess.Utility;
using Medical_Rgistrations.APIModels;
using Medical_Rgistrations.ControllerBase;
using Medical_Rgistrations.RestSharpContext;
using Medical_Rgistrations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Buffers.Text;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.Controllers
{
    [Area("Administrator")]
    public class MenuController : BasePageController
    {

        private readonly IHostingEnvironment _hosting;
        private readonly IConfiguration _Config;
        private static string Message;
        ApiResponse apiResponse;
        public MenuController(IConfiguration config, IHostingEnvironment hostingEnvironment) : base(config)
        {

            this._hosting = hostingEnvironment;
            this._Config = config;
        }
        //[Route("DeleteFaculty")]
        //[HttpPost]
        //public async Task<ApiResponse> DeleteFaculty(string id)
        //{
        //    apiResponse = new ApiResponse();
        //    try
        //    {
        //        RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);
        //        restsharpClient.SetBasicAuthenticator(api_username, api_password);
        //        var restClient = await restsharpClient.GetClientInstance("/Faculty/RemoveFacultyById/" + id);
        //        var response = await restClient.PostAsync(restsharpClient._request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        apiResponse.Success = false;
        //        apiResponse.Message = e.Message;
        //        return apiResponse;
        //    }
        //    return apiResponse;
        //}
        //[Route("FacultyActive")]
        //[HttpPost]
        //public async Task<JsonResult> FacultyActive(MassActive massActive)
        //{
        //    apiResponse = new ApiResponse();
        //    try
        //    {
        //        RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);
        //        restsharpClient.SetBasicAuthenticator(api_username, api_password);
        //        var restClient = await restsharpClient.GetClientInstance("/Faculty/MassUpdate");
        //        restsharpClient._request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(massActive));
        //        var response = await restClient.PostAsync(restsharpClient._request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        apiResponse.Success = false;
        //        apiResponse.Message = e.Message;
        //        return Json(apiResponse);
        //    }
        //    return Json(apiResponse);
        //}


        [Route("Admin-Menu")]
        [HttpGet]
        public async Task<IActionResult> MenuMaster(Guid? id)
        {
            var model = new MenuApisVM();

            ViewBag.message = Message;
            RestsharpClient restsharpClient = new RestsharpClient(apiBaseUrl);

            restsharpClient.SetBasicAuthenticator(api_username, api_password);

            var restClient = await restsharpClient.GetClientInstance("/Menu/GetParentMenus?id=" + id);

            var response = await restClient.GetAsync(restsharpClient._request);

            if (response.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                model = JsonConvert.DeserializeObject<MenuApisVM>(apiResponse.Data);
                ViewBag.ParentMenuNameList = model.MenuList;
            }
            return View(model);
        }
        [Route("MenuList")]
        public async Task<JsonResult> MenuList()
        {
            apiResponse = new ApiResponse();
            try
            {

                RestsharpClient restsharpClient = new RestsharpClient(apiBaseUrl);

                restsharpClient.SetBasicAuthenticator(api_username, api_password);

                var restClient = await restsharpClient.GetClientInstance("/Menu/GetMenus");

                var response = await restClient.GetAsync(restsharpClient._request);

                if (response.IsSuccessStatusCode)
                {
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                    return Json(apiResponse.Data);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Json(apiResponse.Data);

        }
        [Route("SaveMenu")]
        [HttpPost]
        public async Task<IActionResult> SaveMenu(Menu model)
        {

            //faculty.Faculties=await PopulateFaculties();

            if (ModelState.IsValid)
            {

                RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);

                restsharpClient.SetBasicAuthenticator(api_username, api_password);

                //var filename = await Upload(faculty.ProfileImg);

                var requestData = new Menu
                {
                    Active = model.Active,
                    MenuId = model.MenuId,
                    MenuName = model.MenuName,
                    ParentMenuId = model.ParentMenuId,
                    ParentMenuName = model.ParentMenuName,
                };


                var restClient = await restsharpClient.GetClientInstance("/Menu/AddEditMenu");

                restsharpClient._request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(requestData));

                var response = await restClient.PostAsync(restsharpClient._request);

                if (response.IsSuccessStatusCode)
                {
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                    if (apiResponse != null && apiResponse.Success)
                    {
                        Message = apiResponse.Message;
                        return RedirectToAction("MenuMaster");
                    }
                }
            }

            return View(model);
        }
        [Route("MenuActive")]
        [HttpPost]
        public async Task<JsonResult> MenuActive(MassActive massActive)
        {
            apiResponse = new ApiResponse();
            try
            {
                RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);
                restsharpClient.SetBasicAuthenticator(api_username, api_password);
                var restClient = await restsharpClient.GetClientInstance("/Menu/MassUpdate");
                restsharpClient._request.AddJsonBody(Newtonsoft.Json.JsonConvert.SerializeObject(massActive));
                var response = await restClient.PostAsync(restsharpClient._request);
                if (response.IsSuccessStatusCode)
                {
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                }
            }
            catch (Exception e)
            {
                apiResponse.Success = false;
                apiResponse.Message = e.Message;
                return Json(apiResponse);
            }
            return Json(apiResponse);
        }

        [Route("GetMenus")]
        public async Task<JsonResult> GetMenus()
        {
            var jsonresponse = new ApiResponse();
            List<Menu> faculties = new List<Menu>();
            try
            {
                RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);
                restsharpClient.SetBasicAuthenticator(api_username, api_password);
                var restClient = await restsharpClient.GetClientInstance("/Menu/GetMenus");
                var response = await restClient.GetAsync(restsharpClient._request);
                if (response.IsSuccessStatusCode)
                {
                    jsonresponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                    if (jsonresponse != null && jsonresponse.Success)
                    {
                        faculties = JsonConvert.DeserializeObject<List<Menu>>(jsonresponse.Data);

                    }
                }
                jsonresponse.Success = true;
                jsonresponse.Data = jsonresponse.Data;
            }
            catch (Exception)
            {
                throw;
            }
            return Json(jsonresponse.Data);
        }
        [Route("EditMenu")]
        [HttpGet]
        public async Task<IActionResult> EditMenu(string id)
        {
            ViewBag.message = "";

            FacultyEditViewModel model = new FacultyEditViewModel();

            try
            {
                RestsharpClient restsharpClient = new RestsharpClient(base.apiBaseUrl);

                restsharpClient.SetBasicAuthenticator(api_username, api_password);

                var restClient = await restsharpClient.GetClientInstance("/Menu/GetMenuById/" + id);

                var response = await restClient.PostAsync(restsharpClient._request);

                if (response.IsSuccessStatusCode)
                {
                    var Apiresponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                    if (Apiresponse != null && Apiresponse.Success)
                    {
                        ViewBag.message = Apiresponse.Message;

                        var res = JsonConvert.DeserializeObject<Faculty>(Apiresponse.Data);

                        model = new FacultyEditViewModel
                        {
                            FacultyId = res.FacultyId,
                            Description = res.Description,
                            Email = res.Email,
                            Name = res.Name,
                            InstituteName = res.InstituteName,
                            ProfileName = res.ProfileName,
                            Active = res.Active,
                            FacultyType = res.FacultyType,
                            InstaLink = res.InstaLink,
                            FacebookLink = res.FacebookLink,
                            TwitterLink = res.TwitterLink,
                            LinkedInLink = res.LinkedInLink,
                        };

                        return View(model);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }
    }
}
