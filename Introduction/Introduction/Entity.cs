namespace Introduction
{
    class Entity
    {
        static int nextSerialNo;
        readonly int serialNo;

        public Entity()
        {
            serialNo = nextSerialNo++;
        }

        public int GetSerialNo()
        {
            return serialNo;
        }

        public static int GetNextSerialNo()
        {
            return nextSerialNo;
        }

        public static void SetNextSerialNo(int value)
        {
            nextSerialNo = value;
        }
    }
}
