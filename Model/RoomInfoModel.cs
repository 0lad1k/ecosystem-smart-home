namespace ecosystem_smart_home_rest_api
{
    public class RoomInfo
    {
        public long Id { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public  DateTime DateLastCheckState { get; set; }  
    }
}