using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IdealsTest.Core.Models;
using IdealsTest.Core.Services;
using IdealsTest.Files.Models;

namespace IdealsTest.Files.Controllers
{
    public class FilesController : ApiController
    {
        #region Private Members 

        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctors

        public FilesController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        [ActionName("Add")]
        [HttpPost]
        public HttpResponseMessage AddFileInfo(FileInfoViewModel[] fileInfo)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            var fileInformations = _mapper.Map<FileInfoViewModel[], IList<FileInformation>>(fileInfo);

            var validFileInformation = _fileService.ValidateUniqueness(fileInformations);

            var files = _fileService.AddFiles(validFileInformation);

            return Request.CreateResponse(HttpStatusCode.OK, files);
        }

        #endregion
    }
}
