//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: command.proto
namespace message
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Login")]
  public partial class Login : global::ProtoBuf.IExtensible
  {
    public Login() {}
    
    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private string _password = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"password", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string password
    {
      get { return _password; }
      set { _password = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"StudentInfo")]
  public partial class StudentInfo : global::ProtoBuf.IExtensible
  {
    public StudentInfo() {}
    
    private int _index = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int index
    {
      get { return _index; }
      set { _index = value; }
    }
    private string _number = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string number
    {
      get { return _number; }
      set { _number = value; }
    }
    private string _name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private string _school = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"school", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string school
    {
      get { return _school; }
      set { _school = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private int _foreign = default(int);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"foreign", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int foreign
    {
      get { return _foreign; }
      set { _foreign = value; }
    }
    private int _political = default(int);
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"political", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int political
    {
      get { return _political; }
      set { _political = value; }
    }
    private int _business_one = default(int);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"business_one", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int business_one
    {
      get { return _business_one; }
      set { _business_one = value; }
    }
    private string _business_two_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"business_two_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string business_two_name
    {
      get { return _business_two_name; }
      set { _business_two_name = value; }
    }
    private int _business_two = default(int);
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"business_two", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int business_two
    {
      get { return _business_two; }
      set { _business_two = value; }
    }
    private int _score = default(int);
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int score
    {
      get { return _score; }
      set { _score = value; }
    }
    private float _operation = default(float);
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"operation", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float operation
    {
      get { return _operation; }
      set { _operation = value; }
    }
    private float _hear = default(float);
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"hear", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float hear
    {
      get { return _hear; }
      set { _hear = value; }
    }
    private bool _is_first = default(bool);
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"is_first", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool is_first
    {
      get { return _is_first; }
      set { _is_first = value; }
    }
    private int _school_score = default(int);
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"school_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int school_score
    {
      get { return _school_score; }
      set { _school_score = value; }
    }
    private int _introduction_score = default(int);
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"introduction_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int introduction_score
    {
      get { return _introduction_score; }
      set { _introduction_score = value; }
    }
    private int _translation_score = default(int);
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"translation_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int translation_score
    {
      get { return _translation_score; }
      set { _translation_score = value; }
    }
    private int _topic_score = default(int);
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"topic_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int topic_score
    {
      get { return _topic_score; }
      set { _topic_score = value; }
    }
    private int _answer_score = default(int);
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"answer_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int answer_score
    {
      get { return _answer_score; }
      set { _answer_score = value; }
    }
    private int _result_score = default(int);
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"result_score", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int result_score
    {
      get { return _result_score; }
      set { _result_score = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Students")]
  public partial class Students : global::ProtoBuf.IExtensible
  {
    public Students() {}
    
    private readonly global::System.Collections.Generic.List<message.StudentInfo> _student = new global::System.Collections.Generic.List<message.StudentInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"student", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<message.StudentInfo> student
    {
      get { return _student; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}