namespace TDShooter.SaveLoad
{
    /// <summary>
    /// ��������� ������������ �������� ����
    /// </summary>
    public interface ISavable
    {
        public string SaveThis();
        public void LoadThis(string data);
    }
}