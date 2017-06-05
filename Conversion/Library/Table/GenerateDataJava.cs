﻿using System.Text;
public class GenerateDataJava : IGenerate
{
    public GenerateDataJava() : base(PROGRAM.Java) { }
    protected override string Generate_impl()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("package " + m_Package + ";");
        builder.Append(TemplateJava.Head);
        builder.Append(@"public class __ClassName implements IData {");
        builder.Append(GenerateMessageFields());
        builder.Append(GenerateMessageGetData());
        builder.Append(GenerateMessageIsInvalid());
        builder.Append(GenerateJavaToString());
        builder.Append(GenerateMessageRead());
        builder.Append(@"
}");
        builder.Replace("__ClassName", m_ClassName);
        return builder.ToString();
    }
    string GenerateMessageFields()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"
    private boolean m_IsInvalid = false;");
        bool first = true;
        foreach (var field in m_Fields) {
            string str = "";
            if (field.Array) {
                str = @"
    private List<__Type> ___Name;
    /** __Note  默认值(__Default) */
    public List<__Type> get__Name() { return ___Name; }";
            } else {
                str = @"
    private __Type ___Name;
    /** __Note  默认值(__Default) */
    public __Type get__Name() { return ___Name; }";
                if (first && (bool)m_Parameter) {
                    first = false;
                    str += @"
    public __Type ID() { return ___Name; }";
                }
            }
            str = str.Replace("__Name", field.Name);
            str = str.Replace("__Note", field.Comment);
            str = str.Replace("__Default", field.Default);
            str = str.Replace("__Type", GetCodeType(field.Type));
            builder.Append(str);
        }
        return builder.ToString();
    }
    string GenerateMessageGetData()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"
    public Object GetData(String key ) {");
        foreach (var field in m_Fields)
        {
            builder.Append(@"
        if (key.equals(""__Key"")) return ___Key;".Replace("__Key", field.Name));
        }
        builder.Append(@"
        return null;
    }");
        return builder.ToString();
    }
    string GenerateMessageIsInvalid()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"
    public boolean IsInvalid() { return m_IsInvalid; }
    private boolean IsInvalid_impl() {");
        foreach (var field in m_Fields) {
            string str = @"
        if (!TableUtil.IsInvalid(this.___Name)) return false;";
            str = str.Replace("__Name", field.Name);
            builder.Append(str);
        }
        builder.Append(@"
        return true;
    }");
        return builder.ToString();
    }
    string GenerateMessageRead()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(@"
    public static __ClassName Read(TableManager tableManager, String fileName, ScorpioReader reader) {
        __ClassName ret = new __ClassName();");
        foreach (var field in m_Fields) {
            string str = "";
            if (field.Array) {
                str = @"
        {
            int number = reader.ReadInt32();
            ArrayList<__Type> list = new ArrayList<__Type>();
            for (int i = 0;i < number; ++i) { list.add(__FieldRead); }
            ret.___Name = Collections.unmodifiableList(list);
        }";
            } else {
                str = @"
        ret.___Name = __FieldRead;";
            }
            if (field.Attribute != null && field.Attribute.GetValue("Language").LogicOperation()) {
                str = @"
        reader.ReadString();
        ret.___Name = __FieldRead;";
                str = str.Replace("__FieldRead", string.Format("tableManager.getLanguageText(fileName +  \"_{0}_\" + ret._ID)", field.Name));
            } else {
                str = str.Replace("__FieldRead", field.IsBasic ? "reader.__Read()" : (field.Enum ? "__Type.valueOf(reader.ReadInt32())" : "__Type.Read(tableManager, fileName, reader)"));
            }
            str = str.Replace("__Read", field.IsBasic ? field.Info.ReadFunction : "");
            str = str.Replace("__Type", GetCodeType(field.Type));
            str = str.Replace("__Index", field.Index.ToString());
            str = str.Replace("__Name", field.Name);
            builder.Append(str);
        }
        builder.Append(@"
        ret.m_IsInvalid = ret.IsInvalid_impl();
        return ret;
    }");
        return builder.ToString();
    }
}
