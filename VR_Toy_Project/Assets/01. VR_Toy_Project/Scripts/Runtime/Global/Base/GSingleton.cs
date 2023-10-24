
public class GSingleton<T> : GComponent where T : GSingleton<T>
{
    private static T instance_ = default;

    public static T Instance
    {
        get
        { 
            if(GSingleton<T>.instance_ == default || instance_ == default)
            {
                if(GFunc.GetRootObj(typeof(T).ToString()) == default)
                {
                    GSingleton<T>.instance_ 
                        = GFunc.CreateObj<T>(typeof(T).ToString());
                }
                else
                { 
                    GSingleton<T>.instance_
                        = GFunc.GetRootObj(typeof(T).ToString()).AddComponent<T>();
                }  
            }
            return instance_; 
        }

    }
}
