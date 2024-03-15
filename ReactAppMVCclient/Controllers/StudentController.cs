using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactAppMVCclient.Models;
using System.Text;

namespace ReactAppMVCclient.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            List<Student> students = new List<Student>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:5164/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }

            }
            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"http://localhost:5164/api/Students/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Gửi yêu cầu POST để tạo sinh viên mới
                    var jsonStudent = JsonConvert.SerializeObject(student);
                    var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");

                    using (var response = await client.PostAsync("http://localhost:5164/api/Students", content))
                    {
                        response.EnsureSuccessStatusCode(); // Đảm bảo yêu cầu thành công
                    }
                }
                // Nếu tạo thành công, chuyển hướng về trang danh sách sinh viên
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và hiển thị lại form tạo sinh viên với thông báo lỗi
                ModelState.AddModelError("", "Error creating student: " + ex.Message);
                return View(student);
            }
        }



        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"http://localhost:5164/api/Students/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var jsonStudent = JsonConvert.SerializeObject(student);
                    var content = new StringContent(jsonStudent, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"http://localhost:5164/api/Students/{id}", content);
                    response.EnsureSuccessStatusCode();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error editing student: " + ex.Message);
                return View(student);
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Student student = null;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"http://localhost:5164/api/Students/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"http://localhost:5164/api/Students/{id}");
                    response.EnsureSuccessStatusCode();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error deleting student: " + ex.Message);
                return View();
            }
        }
    }
}
