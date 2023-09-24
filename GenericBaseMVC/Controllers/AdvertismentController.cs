using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseMVC.Controllers
{
    [Authorize]
    public class AdvertismentController : Controller
    {
        public IMapper _mapper { get; }

        public AdvertismentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var advertDtos = await new AdvertisingService().Get();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertViewModel model)
        {
            string csv = "";
            var firstImage = string.Empty;
            foreach (var upload in model.uploads)
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

                model.uploadPaths.Add(fileNameWithPath);    
                firstImage = fileNameWithPath;
                csv += fileName + ",";

            }

            model.ImagePath01 = model.uploadPaths[0];
            if (model.uploadPaths.Count>1)
            {
                model.ImagePath02 = model.uploadPaths[1]; 
            }
            if (model.uploadPaths.Count > 2)
            {
                model.ImagePath03 = model.uploadPaths[2];
            }
            var dto = _mapper.Map<AdvertisingDto>(model);
            var advertDtos = await new AdvertisingService().Post(dto);

            return View();
        }

        public async Task<IActionResult> Hub()
        {
            var advertDtos = await new AdvertisingService().Get("none");

            var model = new HubViewModel();

            model.adverts = _mapper.Map<List<SideAdvertViewModel>>(advertDtos);

            var email = User.Identity.Name;
            model.settings = await SettingsHandler.GetSettings(email);

            return View("AdvertisingHub",model);
        }
    }
}
