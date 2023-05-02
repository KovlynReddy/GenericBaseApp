using AutoMapper;
using GenericAppDLL.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    public class JournalController : Controller
    {
        public IMapper mapper { get; }

        public JournalController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IActionResult> ViewAll()
        {
            var model = new ViewListJournalViewModel();
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();
            model.settings.SelectedTheme = currentCustomer.SelectedTheme;

            var journals = await new JournalService().Get(currentCustomer.ModelGuid);


            model.UserGuid = currentCustomer.ModelGuid;
            model.journals = mapper.Map<List<JournalViewModel>>(journals);
            foreach (var journal in model.journals)
            {
                var csv = journal.uploadPaths;
                var files = csv.Split(',').ToList();
                files.Remove("");
                journal.uploadPathsList = files;

            }


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            CreateJournalViewModel model = new CreateJournalViewModel();
            model.settings.SelectedTheme = currentCustomer.SelectedTheme;
            model.UserGuid = currentCustomer.ModelGuid;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJournalViewModel newJournal)
        {
            var _customerService = new CustomerService();
            var email = User.Identity.Name;
            var currentCustomer = (await _customerService.Get(email)).FirstOrDefault();

            string csv = "";
            foreach (var upload in newJournal.uploads)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(upload.FileName);
                string fileName = upload.FileName + Guid.NewGuid().ToString() + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    upload.CopyTo(stream);
                }
                csv += fileName + ",";

            }


            var dto = new JournalEntryDto() { 
            Description = newJournal.Description ?? string.Empty,
            ItemGuid = newJournal.ItemGuid ?? string.Empty,
            UserGuid = newJournal.UserGuid ?? string.Empty,
            Title = newJournal.Title ?? string.Empty,
            uploadPaths = csv,
            //uploads = newJournal.uploads,
            Body = newJournal.Body ?? string.Empty,
            CreatedDateTimeString = DateTime.Now.ToString(),
            CompletedDateTime = DateTime.Now,
            ModelGuid = Guid.NewGuid().ToString(),
            CreatorGuid = newJournal.UserGuid
            };

            var results = await new JournalService().Post(dto);


            var points = new PointsDto()
            {
                AccountGuid = currentCustomer.AccountGuid,
                Description = "Post Created",
                Type = 1,
                SenderType = 1,
                UserGuid = currentCustomer.ModelGuid,
                ModelGuid = Guid.NewGuid().ToString(),
                Amount = 150,
                CreatedDateTime = DateTime.Now.ToString(),
            };

            await new PointsService().Post(points);

            return View();
        }
    }
}
