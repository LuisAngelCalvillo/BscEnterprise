﻿using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using UI.Authorization;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController(IReportService reportService) : ControllerBase
    {
        private readonly IReportService _reportService = reportService;

        [HttpGet("Product")]
        [PermissionAuthorize("Product.Report")]
        public async Task<IActionResult> ReportProducts()
        {
            ResponseDataDto<byte[]> response = new();
            response = await _reportService.GetInformationForProductsReport();
            if (response.Completed && response.Data != null)
            {
                return File(response.Data, "application/pdf", "ProductReport.pdf");
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
