using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Тест.Data;
using Тест.Models;

namespace Тест.Controllers
{
    public class LogInController : Controller
    {
        private readonly LogInContext _context;

        public LogInController(LogInContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nuts, string list, string money, string pills, string ticket, string action,
            string graf, string balls, string birz, string value)
        {
            //получаем БД
            var users = from m in _context.LogIn orderby m.Id select m;
            //Проверяем тест
            int answer = 0;
            if (nuts == "1") answer += 1;
            if (list == "3") answer += 1;
            if (money == "3") answer += 1;
            if (pills == "2") answer += 1;
            if (ticket == "4") answer += 1;
            if (action == "1") answer += 1;
            if (graf == "3") answer += 1;
            if (balls == "2") answer += 1;
            if (birz == "4") answer += 1;
            if (value == "1") answer += 1;
            //Берём последнюю запись, т.е. нынешнего пользователя
            LogIn user = users.Last();
            //Т.к. пользователь впервый раз проходит тест, то его поля верных и неверных ответов пока равны 0, после его ответа они изменят значение, но если он вернётся и попытается 
            //исправить свои ответы, ему это не удастся, т.к. эти поля уже будут заполнены ответами и он просто вернётся на страницу регистрации
            if (user.False == 0 && user.True == 0)
            {
                //вычисляем поля верных и неверных ответов и обновляем БД
                user.True = answer; user.False = 10 - answer;
                _context.Update(user);
                //сохраняем изменения
                await _context.SaveChangesAsync();
                //отправляем письмо
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Администрация", "myrabota269@gmail.com"));
                emailMessage.To.Add(new MailboxAddress(user.Name, user.Email));
                emailMessage.Subject = "Тестирование";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"{user.Name} {user.FirstName}, Вы набрали {user.True} из 10 баллов."
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("myrabota269@gmail.com", "1q2w3E4R$");
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            return RedirectToAction(nameof(Create));
            
        }
        // GET: LogIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstName,Email")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                var mails = from m in _context.LogIn orderby m.Email select m.Email;
                foreach(var mail in mails)
                {
                    if (mail == logIn.Email)
                    {
                        ViewBag.Message = "Sorry, but this mail already exists!";
                        return View(logIn);
                    }
                }
                _context.Add(logIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logIn);
        }
        private bool LogInExists(int id)
        {
            return _context.LogIn.Any(e => e.Id == id);
        }
    }
}
