using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cifrado;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class rsaController : ControllerBase
    {
        //GET  /api/rsa/keys/{p}/{q}
        [HttpPost("{p}/{q}")]
        public async Task<FileResult> keys(int p, int q)
        {
            var files = Request.Form.Files;
            var key = Request.Form.Keys;
            string s_llave = string.Empty;
            FileInfo fileInfoCipher = null;

            if (key.Count == 1)
            {
                foreach (string formkey in key)
                {
                    s_llave = Convert.ToString(Request.Form[formkey]);
                }
            }
            if (files.Count == 1)
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.GetTempFileName();

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        fileInfoCipher = new FileInfo(filePath);
                    }
                    if (fileInfoCipher != null)
                    {
                        Cifrado.Clases.SDES cifradoSDES = new Cifrado.Clases.SDES(null, fileInfoCipher);
                        int i_llave = 0;
                        int.TryParse(s_llave, out i_llave);
                        s_llave = Convert.ToString(i_llave, 2);
                        s_llave = s_llave.PadLeft(10, '0');
                        cifradoSDES.ObtenerLlave(s_llave);
                        List<byte> ArrayCompressFile = cifradoSDES.Descifrar();
                        var ArrayBytesCompress = ArrayCompressFile.ToArray();
                        string fileName = BuscarNombreOriginal(files[0].FileName);

                        return File(ArrayBytesCompress, "application/octet-stream", fileName);
                    }
                }
            }

            return null;
        }
    }
}