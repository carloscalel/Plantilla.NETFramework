using System;
using System.IO;
using System.Web;
using MyApp.Web.Data;

namespace MyApp.Web.Security
{
    public interface ILogger
    {
        void Info(string message, string user = null);
        void Error(string message, Exception ex, string user = null);
    }

    public class Logger : ILogger
    {
        public void Info(string message, string user = null)
        {
            Write("INFO", message, null, user);
        }

        public void Error(string message, Exception ex, string user = null)
        {
            Write("ERROR", message, ex?.ToString(), user);
        }

        private void Write(string level, string message, string detail, string user)
        {
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{level}|{user}|{message}|{detail}";
            var path = HttpContext.Current.Server.MapPath("~/Logs/app.log");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.AppendAllLines(path, new[] { line });

            using (var db = new DbContextApp())
            {
                db.LogsAplicacion.Add(new LogAplicacion
                {
                    Nivel = level,
                    Mensaje = message,
                    Detalle = detail,
                    UsuarioDominio = user,
                    Fecha = DateTime.Now
                });
                db.SaveChanges();
            }
        }
    }
}
