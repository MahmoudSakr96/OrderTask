using Microsoft.AspNetCore.Mvc;
using OrderTask.Business;
using OrderTask.Business.Dto;
using OrderTask.UI.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderTask.Business.Contracts.Persistence;
using OlderTask.Domain.Entities;
using OlderTask.Infrastructure;
using AutoMapper;
using OrderTask.Business.Contracts.Feature;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using OrderTask.Business.Helper;

namespace OrderTask.UI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderAppService _orderAppService;
        public OrderController(ILogger<HomeController> logger, IOrderAppService orderAppService)
        {
            _logger = logger;
            _orderAppService = orderAppService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var orders = await _orderAppService.GetAllAsync();
            foreach (var order in orders)
            {
                order.HijriDate = ConverDateCalenderClass.ConvertDateCalendar(order.Date, "Hijri", "en-US");
            }
            return View(orders);
        }

        [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateAsync(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                await _orderAppService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> EditAsync(int id)
        {
            var order = await _orderAppService.GetByIdAsync(id);
            //order.Date = OrderController.ConvertDateCalendar(order.Date, "Hijri", "en-US");
            return View(order);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAsync(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                var order = await _orderAppService.UpdateAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> DetailAsync(int id)
        {

            var order = await _orderAppService.GetByIdAsync(id);
            return View(order);
        }

        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var order = await _orderAppService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }


    }
}