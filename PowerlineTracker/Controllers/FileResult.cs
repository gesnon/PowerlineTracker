using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PowerlineTracker.Controllers
{
    public class FileResult : IHttpActionResult
    {
        MemoryStream _data;
        string _fileName;
        HttpRequestMessage _httpRequestMessage;
        HttpResponseMessage _httpResponseMessage;

        public FileResult(MemoryStream data, HttpRequestMessage request, string filename)
        {
            _data = data;
            _httpRequestMessage = request;
            _fileName = filename;
        }

        public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            _httpResponseMessage = _httpRequestMessage.CreateResponse(HttpStatusCode.OK);
            _httpResponseMessage.Content = new StreamContent(_data);
            //_httpResponseMessage.Content = new ByteArrayContent(_data.ToArray());
            _httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            _httpResponseMessage.Content.Headers.ContentDisposition.FileName = _fileName;
            _httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return System.Threading.Tasks.Task.FromResult(_httpResponseMessage);
        }
    }
}