// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/BuildMaze.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Server {

  /// <summary>Holder for reflection information generated from Protos/BuildMaze.proto</summary>
  public static partial class BuildMazeReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/BuildMaze.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BuildMazeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZQcm90b3MvQnVpbGRNYXplLnByb3RvEgVncmVldCJqCgtNYXplUmVxdWVz",
            "dBIRCglhbGdvcml0aG0YASABKAkSDQoFd2lkdGgYAiABKAMSDgoGaGVpZ2h0",
            "GAMgASgDEhMKC3JlbW92ZVdhbGxzGAQgASgDEhQKDGV4aXRMb2NhdGlvbhgF",
            "IAEoCSIZCglCdWlsdE1hemUSDAoEbWF6ZRgBIAEoCTJACgtNYXplQnVpbGRl",
            "chIxCglCdWlsZE1hemUSEi5ncmVldC5NYXplUmVxdWVzdBoQLmdyZWV0LkJ1",
            "aWx0TWF6ZUIJqgIGU2VydmVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.MazeRequest), global::Server.MazeRequest.Parser, new[]{ "Algorithm", "Width", "Height", "RemoveWalls", "ExitLocation" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Server.BuiltMaze), global::Server.BuiltMaze.Parser, new[]{ "Maze" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class MazeRequest : pb::IMessage<MazeRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MazeRequest> _parser = new pb::MessageParser<MazeRequest>(() => new MazeRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MazeRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.BuildMazeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MazeRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MazeRequest(MazeRequest other) : this() {
      algorithm_ = other.algorithm_;
      width_ = other.width_;
      height_ = other.height_;
      removeWalls_ = other.removeWalls_;
      exitLocation_ = other.exitLocation_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MazeRequest Clone() {
      return new MazeRequest(this);
    }

    /// <summary>Field number for the "algorithm" field.</summary>
    public const int AlgorithmFieldNumber = 1;
    private string algorithm_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Algorithm {
      get { return algorithm_; }
      set {
        algorithm_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "width" field.</summary>
    public const int WidthFieldNumber = 2;
    private long width_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Width {
      get { return width_; }
      set {
        width_ = value;
      }
    }

    /// <summary>Field number for the "height" field.</summary>
    public const int HeightFieldNumber = 3;
    private long height_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Height {
      get { return height_; }
      set {
        height_ = value;
      }
    }

    /// <summary>Field number for the "removeWalls" field.</summary>
    public const int RemoveWallsFieldNumber = 4;
    private long removeWalls_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long RemoveWalls {
      get { return removeWalls_; }
      set {
        removeWalls_ = value;
      }
    }

    /// <summary>Field number for the "exitLocation" field.</summary>
    public const int ExitLocationFieldNumber = 5;
    private string exitLocation_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ExitLocation {
      get { return exitLocation_; }
      set {
        exitLocation_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MazeRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MazeRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Algorithm != other.Algorithm) return false;
      if (Width != other.Width) return false;
      if (Height != other.Height) return false;
      if (RemoveWalls != other.RemoveWalls) return false;
      if (ExitLocation != other.ExitLocation) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Algorithm.Length != 0) hash ^= Algorithm.GetHashCode();
      if (Width != 0L) hash ^= Width.GetHashCode();
      if (Height != 0L) hash ^= Height.GetHashCode();
      if (RemoveWalls != 0L) hash ^= RemoveWalls.GetHashCode();
      if (ExitLocation.Length != 0) hash ^= ExitLocation.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Algorithm.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Algorithm);
      }
      if (Width != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(Width);
      }
      if (Height != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(Height);
      }
      if (RemoveWalls != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(RemoveWalls);
      }
      if (ExitLocation.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ExitLocation);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Algorithm.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Algorithm);
      }
      if (Width != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(Width);
      }
      if (Height != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(Height);
      }
      if (RemoveWalls != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(RemoveWalls);
      }
      if (ExitLocation.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ExitLocation);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Algorithm.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Algorithm);
      }
      if (Width != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Width);
      }
      if (Height != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Height);
      }
      if (RemoveWalls != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(RemoveWalls);
      }
      if (ExitLocation.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExitLocation);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MazeRequest other) {
      if (other == null) {
        return;
      }
      if (other.Algorithm.Length != 0) {
        Algorithm = other.Algorithm;
      }
      if (other.Width != 0L) {
        Width = other.Width;
      }
      if (other.Height != 0L) {
        Height = other.Height;
      }
      if (other.RemoveWalls != 0L) {
        RemoveWalls = other.RemoveWalls;
      }
      if (other.ExitLocation.Length != 0) {
        ExitLocation = other.ExitLocation;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
            Algorithm = input.ReadString();
            break;
          }
          case 16: {
            Width = input.ReadInt64();
            break;
          }
          case 24: {
            Height = input.ReadInt64();
            break;
          }
          case 32: {
            RemoveWalls = input.ReadInt64();
            break;
          }
          case 42: {
            ExitLocation = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Algorithm = input.ReadString();
            break;
          }
          case 16: {
            Width = input.ReadInt64();
            break;
          }
          case 24: {
            Height = input.ReadInt64();
            break;
          }
          case 32: {
            RemoveWalls = input.ReadInt64();
            break;
          }
          case 42: {
            ExitLocation = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class BuiltMaze : pb::IMessage<BuiltMaze>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<BuiltMaze> _parser = new pb::MessageParser<BuiltMaze>(() => new BuiltMaze());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BuiltMaze> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Server.BuildMazeReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BuiltMaze() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BuiltMaze(BuiltMaze other) : this() {
      maze_ = other.maze_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BuiltMaze Clone() {
      return new BuiltMaze(this);
    }

    /// <summary>Field number for the "maze" field.</summary>
    public const int MazeFieldNumber = 1;
    private string maze_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Maze {
      get { return maze_; }
      set {
        maze_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BuiltMaze);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BuiltMaze other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Maze != other.Maze) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Maze.Length != 0) hash ^= Maze.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Maze.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Maze);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Maze.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Maze);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Maze.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Maze);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BuiltMaze other) {
      if (other == null) {
        return;
      }
      if (other.Maze.Length != 0) {
        Maze = other.Maze;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
            Maze = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Maze = input.ReadString();
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
