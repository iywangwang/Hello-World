namespace IntelligentPlant.Models
{
    class DeviceItems
    {
        //编号
        public int Id { get; set; }

        //状态
        public bool IsWarning { get; set; }

        public List<VariableItem> Variables { get; set; }
    }
}
