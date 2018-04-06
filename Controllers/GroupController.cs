using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]
        public JsonResult displayAll(){
            ArtistController Artists = new ArtistController();
            List<Artist> allArtists = Artists.allArtists;

            foreach(Group group in allGroups)
            {
                group.Members = allArtists.Where(performer => performer.GroupId == group.Id).ToList();
            }

            return Json(allGroups);
        }

        [Route("groups/name/{name}")]
        [HttpGet]
        public JsonResult groupName(string name){
            List<Group> groupMatch = allGroups.Where(group => group.GroupName.Contains($"{name}")).ToList();
            return Json(groupMatch);
        }

        [Route("groups/id/{id}")]
        [HttpGet]
        public JsonResult groupid(int id){
            List<Group> groupMatch = allGroups.Where(group => group.Id == id).ToList();
            return Json(groupMatch);
        }

    }
}