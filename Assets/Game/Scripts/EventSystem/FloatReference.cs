using System;

namespace Core
{
    [Serializable]
    public class FloatReference
    {
        public ReferenceType referenceType;
        
        public FloatVariable data;
        public float constant;

        public float Value
        {
            get
            {
                switch (referenceType)
                {
                    case ReferenceType.Constant:
                        return constant;
                    case ReferenceType.Data:
                        if (data != null)
                            return data.Value;
                        throw new NullReferenceException("variable data is null");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            set
            {
                switch (referenceType)
                {
                    case ReferenceType.Constant:
                        constant = value;
                        break;
                    case ReferenceType.Data:
                        if (data != null)
                            data.Value = value;
                        else
                            throw new NullReferenceException("variable data is null");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}