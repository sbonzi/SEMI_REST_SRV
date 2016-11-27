using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ConectivosService.DataObjects;

namespace ConectivosService.Controllers
{
    public class colectivosController : ApiController
    {
        private TP_SeminarioEntities db = new TP_SeminarioEntities();

        // GET: api/colectivos
        public IQueryable<colectivo> Getcolectivo()
        {
            return db.colectivo;
        }

        // GET: api/colectivos/5
        [ResponseType(typeof(colectivo))]
        public IHttpActionResult Getcolectivo(long id)
        {
            colectivo colectivo = db.colectivo.Find(id);
            if (colectivo == null)
            {
                return NotFound();
            }

            return Ok(colectivo);
        }

        // GET: api/colectivos/5
        [ResponseType(typeof(colectivo))]
        public IHttpActionResult Getcolectivo(string idbeacon)
        {
            colectivo colectivo = null;

            var result = from c in db.colectivo
                            join cb in db.colectivo_beacon 
                            on c.id equals cb.id_colectivo 
                            join b in db.beacon
                            on cb.id_beacon equals b.id 
                            where b.serial.Equals(idbeacon)
                            select c;

            if (result == null)
                return NotFound();
            else
                colectivo = result.First();

            return Ok(colectivo);
        }

        // PUT: api/colectivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcolectivo(long id, colectivo colectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colectivo.id)
            {
                return BadRequest();
            }

            db.Entry(colectivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!colectivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/colectivos
        [ResponseType(typeof(colectivo))]
        public IHttpActionResult Postcolectivo(colectivo colectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.colectivo.Add(colectivo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (colectivoExists(colectivo.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colectivo.id }, colectivo);
        }

        // DELETE: api/colectivos/5
        [ResponseType(typeof(colectivo))]
        public IHttpActionResult Deletecolectivo(long id)
        {
            colectivo colectivo = db.colectivo.Find(id);
            if (colectivo == null)
            {
                return NotFound();
            }

            db.colectivo.Remove(colectivo);
            db.SaveChanges();

            return Ok(colectivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool colectivoExists(long id)
        {
            return db.colectivo.Count(e => e.id == id) > 0;
        }
    }
}