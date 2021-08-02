using Microsoft.AspNetCore.Mvc;
using Monomarket.API.Data;
using Monomarket.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monomarket.API.Controllers
{
    public abstract class DataController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected DataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected ActionResult<ApiData> Created(int id)
        {
            return Created($"{Request.Path.Value}/{id}", new ApiData(id));
        }
    }
}
