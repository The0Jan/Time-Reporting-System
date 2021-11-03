namespace NTR.Models {
    public class EditEntryModel : Entities.Entry{

        public int id {get; set;}

        public EditEntryModel() {}

        public EditEntryModel(Entities.Entry entry, int id){
            this.id = id;
            this.date = entry.date;
            this.code = entry.code;
            this.subcode = entry.subcode;
            this.time = entry.time;
            this.description = entry.description;
        }
    }
}