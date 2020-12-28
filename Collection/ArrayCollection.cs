namespace Collection
{
    class ArrayCollection
    {

        string[] ArrayEle;

        public ArrayCollection(string[] arrayEle)
        {
            ArrayEle = arrayEle;
        }
        
         public string[] getArray(string input)
        {
            ArrayEle[0] = input;
            return ArrayEle;
        } 
       
    }
}