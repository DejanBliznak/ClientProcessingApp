
using Data.Entities;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System.Diagnostics;
using System.Xml.Linq;

namespace ClientProcessingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;

        public HomeController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var clientList = _clientService.GetClients().Result;
            return View(clientList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            var model = new CreateClientModel
            {
                Addresses = new List<CreateAddressModel>
                {
                    new CreateAddressModel { Type =  (int)AddressEnum.HomeAddress },
                    new CreateAddressModel { Type = (int)AddressEnum.WeekendAddres }
                }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateClientModel client)
        {
            if (ModelState.IsValid)
            {
                var response = _clientService.AddClient(client).Result;
                return RedirectToAction("Details", new { id = response.Id });
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var client = _clientService.GetClient(id).Result;

            return View(client);
        }


        [HttpGet]
        public IActionResult ImportXml()
        {


            return View();
        }

        [HttpPost]
        public IActionResult ImportXml(IFormFile xmlFile)
        {
            if (xmlFile != null)
            {
                XDocument xmlDoc = XDocument.Load(xmlFile.OpenReadStream());
                var clients = from c in xmlDoc.Descendants("Client")
                              select new CreateClientModel
                              {                                 
                                  Name = c.Element("Name").Value,
                                  BirthDate = DateTime.Parse(c.Element("BirthDate").Value),
                                  Addresses = c.Element("Addresses").Elements("Address")
                                              .Select(a => new CreateAddressModel
                                              {                                                
                                                  AddressLine = a.Value,
                                                  Type = (int)a.Attribute("Type")
                                              }).ToList()
                              };

                foreach( var client in clients.ToList())
                {
                        _clientService.AddClient(client);
                }

              
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult ExportClientsInJson()
        {
           
            var clients = _clientService.ExportClientsInJson().Result;
            return Json(clients);
        }
    }
}