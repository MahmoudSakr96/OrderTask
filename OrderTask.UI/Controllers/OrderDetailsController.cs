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

namespace OrderTask.UI.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderDetailsAppService _orderDetailsAppService;
        private readonly IOrderAppService _orderAppService;

        public OrderDetailsController(ILogger<HomeController> logger, IOrderDetailsAppService orderDetailsAppService, IOrderAppService orderAppService)
        {
            _logger = logger;
            _orderDetailsAppService = orderDetailsAppService;
            _orderAppService = orderAppService;
        }

        [Authorize]
        public async Task<ActionResult> Index(int id)
        {
            var orderDetail = await _orderDetailsAppService.GetAllByOrderIdAsync(id);
            return View(orderDetail);
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        [Authorize]
        [HttpPost]    
        public async Task<ActionResult> CreateAsync(OrderDetailsDto model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                model.Total = model.Quantity * model.Price;
                await _orderDetailsAppService.AddAsync(model);
                return RedirectToAction("Index", new { id = model.OrderId });
            }
            return View(model); 
        }

        [Authorize]
        public async Task<ActionResult> EditAsync(int id)
        {
            var orderDetail = await _orderDetailsAppService.GetByIdAsync(id);
            return View(orderDetail);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditAsync(OrderDetailsDto model)
        {
            if (ModelState.IsValid)
            {
                model.Total = model.Quantity * model.Price;
                var orderDetail = await _orderDetailsAppService.UpdateAsync(model);
                return RedirectToAction("Index", new { id = model.OrderId });
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> DetailAsync(int id)
        {

            var orderDetail = await _orderDetailsAppService.GetByIdAsync(id);
            return View(orderDetail);
        }

        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var orderDetail = await _orderDetailsAppService.DeleteByIdAsync(id);
            return RedirectToAction("Index", new { id = orderDetail.OrderId });
        }


    }
}