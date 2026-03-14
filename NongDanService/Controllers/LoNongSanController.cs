using Microsoft.AspNetCore.Mvc;
using NongDanService.Models.DTOs;
using NongDanService.Services;

namespace NongDanService.Controllers
{
    [Route("api/lo-nong-san")]
    [ApiController]
    public class LoNongSanController : ControllerBase
    {
        private readonly ILoNongSanService _loNongSanService;

        public LoNongSanController(ILoNongSanService loNongSanService)
        {
            _loNongSanService = loNongSanService;
        }

        /// <summary>
        /// Lấy tất cả lô nông sản
        /// </summary>
        /// <returns>Danh sách lô nông sản</returns>
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _loNongSanService.GetAll();
                return Ok(new
                {
                    success = true,
                    message = "Lấy danh sách lô nông sản thành công",
                    data = data,
                    count = data.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy lô nông sản theo trang trại
        /// </summary>
        /// <param name="maTrangTrai">Mã trang trại</param>
        /// <returns>Danh sách lô nông sản của trang trại</returns>
        [HttpGet("get-by-trang-trai/{maTrangTrai}")]
        public IActionResult GetByTrangTrai(int maTrangTrai)
        {
            try
            {
                if (maTrangTrai <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Mã trang trại không hợp lệ"
                    });
                }

                var data = _loNongSanService.GetByTrangTrai(maTrangTrai);
                return Ok(new
                {
                    success = true,
                    message = "Lấy danh sách lô nông sản thành công",
                    data = data,
                    count = data.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy lô nông sản theo nông dân
        /// </summary>
        /// <param name="maNongDan">Mã nông dân</param>
        /// <returns>Danh sách lô nông sản của nông dân</returns>
        [HttpGet("get-by-nong-dan/{maNongDan}")]
        public IActionResult GetByNongDan(int maNongDan)
        {
            try
            {
                if (maNongDan <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Mã nông dân không hợp lệ"
                    });
                }

                var data = _loNongSanService.GetByNongDan(maNongDan);
                return Ok(new
                {
                    success = true,
                    message = "Lấy danh sách lô nông sản thành công",
                    data = data,
                    count = data.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy lô nông sản theo ID
        /// </summary>
        /// <param name="id">Mã lô nông sản</param>
        /// <returns>Thông tin lô nông sản</returns>
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "ID lô nông sản không hợp lệ"
                    });
                }

                var data = _loNongSanService.GetById(id);
                if (data == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy lô nông sản"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Lấy thông tin lô nông sản thành công",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy lô nông sản theo mã QR
        /// </summary>
        /// <param name="maQR">Mã QR</param>
        /// <returns>Thông tin lô nông sản</returns>
        [HttpGet("get-by-qr/{maQR}")]
        public IActionResult GetByQRCode(string maQR)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maQR))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Mã QR không được để trống"
                    });
                }

                var data = _loNongSanService.GetByQRCode(maQR);
                if (data == null)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy lô nông sản với mã QR này"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Lấy thông tin lô nông sản thành công",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy lô nông sản theo trạng thái
        /// </summary>
        /// <param name="trangThai">Trạng thái (san_sang, da_ban, het_han)</param>
        /// <returns>Danh sách lô nông sản theo trạng thái</returns>
        [HttpGet("get-by-trang-thai")]
        public IActionResult GetByTrangThai([FromQuery] string trangThai)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(trangThai))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Trạng thái không được để trống"
                    });
                }

                var data = _loNongSanService.GetByTrangThai(trangThai);
                return Ok(new
                {
                    success = true,
                    message = $"Lấy danh sách lô nông sản trạng thái '{trangThai}' thành công",
                    data = data,
                    count = data.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Tạo lô nông sản mới
        /// </summary>
        /// <param name="dto">Thông tin lô nông sản</param>
        /// <returns>ID lô nông sản mới</returns>
        [HttpPost("create")]
        public IActionResult Create([FromBody] LoNongSanCreateDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState
                    });
                }

                var newId = _loNongSanService.Create(dto);
                return Ok(new
                {
                    success = true,
                    message = "Tạo lô nông sản thành công",
                    data = new { id = newId }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }

        /// <summary>
        /// Cập nhật lô nông sản
        /// </summary>
        /// <param name="id">Mã lô nông sản</param>
        /// <param name="dto">Thông tin cập nhật</param>
        /// <returns>Kết quả cập nhật</returns>
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] LoNongSanUpdateDTO dto)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "ID lô nông sản không hợp lệ"
                    });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState
                    });
                }

                bool result = _loNongSanService.Update(id, dto);
                if (!result)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy lô nông sản để cập nhật"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Cập nhật lô nông sản thành công"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }



        /// <summary>
        /// Xóa lô nông sản
        /// </summary>
        /// <param name="id">Mã lô nông sản</param>
        /// <returns>Kết quả xóa</returns>
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "ID lô nông sản không hợp lệ"
                    });
                }

                bool result = _loNongSanService.Delete(id);
                if (!result)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Không tìm thấy lô nông sản để xóa"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Xóa lô nông sản thành công"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server: " + ex.Message
                });
            }
        }
    }
}
