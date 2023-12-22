// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/HandleUserStats.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Server {

  /// <summary>Holder for reflection information generated from Protos/HandleUserStats.proto</summary>
  public static partial class HandleUserStatsReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/HandleUserStats.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HandleUserStatsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChxQcm90b3MvSGFuZGxlVXNlclN0YXRzLnByb3RvEgVncmVldBobZ29vZ2xl",
            "L3Byb3RvYnVmL2VtcHR5LnByb3RvIjAKDFVzZXJNYXplVHlwZRIQCghtYXpl",
            "VHlwZRgBIAEoCRIOCgZ1c2VySUQYAiABKAUiQgoIVXNlclRpbWUSDAoEdGlt",
            "ZRgBIAEoCRIYChB0aW1lTWlsbGlzZWNvbmRzGAIgASgFEg4KBnVzZXJJRBgD",
            "IAEoBTKOAQoPVXNlclN0YXRIYW5kbGVyEkAKEVVzZXJJbmNyZW1lbnRNYXpl",
            "EhMuZ3JlZXQuVXNlck1hemVUeXBlGhYuZ29vZ2xlLnByb3RvYnVmLkVtcHR5",
            "EjkKDlVzZXJVcGxvYWRUaW1lEg8uZ3JlZXQuVXNlclRpbWUaFi5nb29nbGUu",
            "cHJvdG9idWYuRW1wdHlCCaoCBlNlcnZlcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.UserMazeType), global::Server.UserMazeType.Parser, new[]{ "MazeType", "UserID" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.UserTime), global::Server.UserTime.Parser, new[]{ "Time", "TimeMilliseconds", "UserID" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class UserMazeType : pb::IMessage<UserMazeType>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<UserMazeType> _parser = new pb::MessageParser<UserMazeType>(() => new UserMazeType());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<UserMazeType> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.HandleUserStatsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserMazeType() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserMazeType(UserMazeType other) : this() {
      mazeType_ = other.mazeType_;
      userID_ = other.userID_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserMazeType Clone() {
      return new UserMazeType(this);
    }

    /// <summary>Field number for the "mazeType" field.</summary>
    public const int MazeTypeFieldNumber = 1;
    private string mazeType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MazeType {
      get { return mazeType_; }
      set {
        mazeType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "userID" field.</summary>
    public const int UserIDFieldNumber = 2;
    private int userID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int UserID {
      get { return userID_; }
      set {
        userID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as UserMazeType);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(UserMazeType other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MazeType != other.MazeType) return false;
      if (UserID != other.UserID) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MazeType.Length != 0) hash ^= MazeType.GetHashCode();
      if (UserID != 0) hash ^= UserID.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (MazeType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MazeType);
      }
      if (UserID != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(UserID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (MazeType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MazeType);
      }
      if (UserID != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(UserID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (MazeType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MazeType);
      }
      if (UserID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(UserID);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(UserMazeType other) {
      if (other == null) {
        return;
      }
      if (other.MazeType.Length != 0) {
        MazeType = other.MazeType;
      }
      if (other.UserID != 0) {
        UserID = other.UserID;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MazeType = input.ReadString();
            break;
          }
          case 16: {
            UserID = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            MazeType = input.ReadString();
            break;
          }
          case 16: {
            UserID = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class UserTime : pb::IMessage<UserTime>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<UserTime> _parser = new pb::MessageParser<UserTime>(() => new UserTime());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<UserTime> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.HandleUserStatsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserTime() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserTime(UserTime other) : this() {
      time_ = other.time_;
      timeMilliseconds_ = other.timeMilliseconds_;
      userID_ = other.userID_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public UserTime Clone() {
      return new UserTime(this);
    }

    /// <summary>Field number for the "time" field.</summary>
    public const int TimeFieldNumber = 1;
    private string time_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Time {
      get { return time_; }
      set {
        time_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "timeMilliseconds" field.</summary>
    public const int TimeMillisecondsFieldNumber = 2;
    private int timeMilliseconds_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int TimeMilliseconds {
      get { return timeMilliseconds_; }
      set {
        timeMilliseconds_ = value;
      }
    }

    /// <summary>Field number for the "userID" field.</summary>
    public const int UserIDFieldNumber = 3;
    private int userID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int UserID {
      get { return userID_; }
      set {
        userID_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as UserTime);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(UserTime other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Time != other.Time) return false;
      if (TimeMilliseconds != other.TimeMilliseconds) return false;
      if (UserID != other.UserID) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Time.Length != 0) hash ^= Time.GetHashCode();
      if (TimeMilliseconds != 0) hash ^= TimeMilliseconds.GetHashCode();
      if (UserID != 0) hash ^= UserID.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Time.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Time);
      }
      if (TimeMilliseconds != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(TimeMilliseconds);
      }
      if (UserID != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(UserID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Time.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Time);
      }
      if (TimeMilliseconds != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(TimeMilliseconds);
      }
      if (UserID != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(UserID);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Time.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Time);
      }
      if (TimeMilliseconds != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TimeMilliseconds);
      }
      if (UserID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(UserID);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(UserTime other) {
      if (other == null) {
        return;
      }
      if (other.Time.Length != 0) {
        Time = other.Time;
      }
      if (other.TimeMilliseconds != 0) {
        TimeMilliseconds = other.TimeMilliseconds;
      }
      if (other.UserID != 0) {
        UserID = other.UserID;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Time = input.ReadString();
            break;
          }
          case 16: {
            TimeMilliseconds = input.ReadInt32();
            break;
          }
          case 24: {
            UserID = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Time = input.ReadString();
            break;
          }
          case 16: {
            TimeMilliseconds = input.ReadInt32();
            break;
          }
          case 24: {
            UserID = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
