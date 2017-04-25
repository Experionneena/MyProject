﻿using Newtonsoft.Json;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RI.SolutionOwner.Web.Controllers
{
    public class SampleSORole2Controller : BaseController
    {
        public async Task<ActionResult> Index()
        
{
            SampleSORoleDto soRole = new SampleSORoleDto();
            soRole.Id = 1;
            soRole.IsActive = true;
            soRole.RoleName = "Name";
            soRole.Description = "Desc";
            soRole.CreatedDate = DateTime.Now;

            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, @"http://localhost:51808/samplesorole2");
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(soRole));
            var content = new ByteArrayContent(data, 0, data.Length);
            content.Headers.Add("Content-Type", "application/json; charset=utf-8");
            content.Headers.Add("Content-Length", data.Length.ToString());
            request.Content = content;

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await client.SendAsync(request);
            var contentData = await response.Content.ReadAsStringAsync();
            var resultObj = JsonConvert.DeserializeObject<CommonDto<SampleSORoleDto>>(contentData);
            var soRoleDto = resultObj.Data;
            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //SampleSORoleDto resultObj = (SampleSORoleDto)json_serializer.DeserializeObject(contentData);

            //var response = await client.GetAsync(@"http://localhost:51808/samplesorole");
            //WebRequest request = WebRequest.Create(@"http://localhost:51808/samplesorole");
            //WebResponse response = request.GetResponse();
            //var jsonString =await response.Content.ReadAsStringAsync();

            return View();
        }

        public async Task<ActionResult> Get()
        {
            var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, @"http://localhost:51808/samplesorole2");
            var response = await client.GetAsync("SORole/Get");
            var contentData = await response.Content.ReadAsStringAsync();
            var resultRoleObj = JsonConvert.DeserializeObject<ISORole>(contentData);
            return View();
        }
    }
}