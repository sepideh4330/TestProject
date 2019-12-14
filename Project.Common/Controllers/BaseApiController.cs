using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project.Common.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected async Task<IActionResult> ExecuteServiceAsync<T>(Func<Task<T>> serviceDelegate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await serviceDelegate.Invoke();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        protected IActionResult GetSimpleData<T>(T data)
        {
            return Ok(data);
        }
    }
}
