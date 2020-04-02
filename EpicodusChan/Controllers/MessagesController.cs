using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpicodusChan.Models;
using Microsoft.EntityFrameworkCore;

namespace EpicodusChan.Solution.Controllers
{
    [Route("api/Groups/{GroupId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private EpicodusChanContext _db; 
        public MessagesController(EpicodusChanContext db)
        {
          _db = db;
        }

        // GET api/Messages
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(int groupId)
        {
         List<Message> messages = _db.Messages.Where(message => message.GroupId == groupId).ToList();
         return messages;
        }

        // GET api/Messages/5
        [HttpGet("{id}")]
        public ActionResult<Message> Get(int groupId, int id)
        {
            return _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
        }

        // POST api/messages
        [HttpPost]
        public void Post(int groupId, [FromBody] Message message)
        {
          message.GroupId = groupId;
          _db.Messages.Add(message);
          Group group = _db.Groups.FirstOrDefault(gp => gp.GroupId == message.GroupId);
          group.Messages.Add(message);
          _db.Entry(group).State = EntityState.Modified;
          _db.SaveChanges(); 
        }

        // PUT api/Messages/5
        [HttpPut("{id}")]
        public void Put(int id, int groupId, [FromBody] Message message)
        {
          message.MessageId = id;
          message.GroupId = groupId;
          _db.Entry(message).State = EntityState.Modified;
          _db.SaveChanges();
        }

        // // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          Message messageToDelete = _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
          _db.Messages.Remove(messageToDelete);
          _db.SaveChanges();
        }
    }
}