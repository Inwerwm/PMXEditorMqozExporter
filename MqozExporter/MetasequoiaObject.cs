using System;
using System.Collections.Generic;
using System.Text;

namespace MetasequoiaObject
{
    public class MetasequoiaObject
    {
        public string Format { get; private set; }
        public float Version { get; private set; }
        public Encoding CodePage { get; set; }
        public string IncludeXML { get; set; }
        public List<MQMaterial> Materials { get; set; }
        public List<MQObject> Objects { get; set; }

        public MetasequoiaObject()
        {
            Format = "Text";
            Version = 1.2f;
            CodePage = Encoding.UTF8;
            IncludeXML = "";
            Materials = new List<MQMaterial>();
            Objects = new List<MQObject>();
        }
    }

    public class MetasequoiaXML
    {
    }

    public class MQMaterial
    {
        public string Name { get; set; }
        /// <summary>
        /// [0]Classic
        /// [1]Constant
        /// [2]Lambert
        /// [3]Phong
        /// [4]Blinn
        /// </summary>
        public byte Shader { get; set; }
        public bool UseVertexColor { get; set; }
        public bool DoubleSideDisplay { get; set; }
        public RGBA Color { get; set; }
        /// <summary>
        /// 0～1
        /// </summary>
        public float Diffuse { get; set; }
        /// <summary>
        /// 0～1
        /// </summary>
        public float Ambient { get; set; }
        /// <summary>
        /// 0～1
        /// </summary>
        public float Emissive { get; set; }
        /// <summary>
        /// 0～1
        /// </summary>
        public float Specular { get; set; }
        /// <summary>
        /// 0～100
        /// </summary>
        public float SpecularPower { get; set; }
        /// <summary>
        /// 0～1
        /// </summary>
        public float Reflect { get; set; }
        /// <summary>
        /// 1～5
        /// </summary>
        public float Refract { get; set; }
        public string TexturePath { get; set; }
        public string AlphaMapPath { get; set; }
        public string NormalMapPath { get; set; }
        /// <summary>
        /// [0]UV
        /// [1]平面
        /// [2]円筒
        /// [3]球
        /// </summary>
        public byte ProjectionType { get; set; }
        public XYZ ProjectionPosition { get; set; }
        public XYZ ProjectionScale { get; set; }
        /// <summary>
        /// -180～180
        /// </summary>
        public XYZ ProjectionAngle { get; set; }
    }

    public class MQObject
    {
        public string Name { get; set; }
        public byte Depth { get; set; }
        public bool Folding { get; set; }
        public XYZ Scale { get; set; }
        public XYZ Rotation { get; set; }
        public XYZ Translation { get; set; }
        /// <summary>
        /// 曲面設定
        /// [0]平面(曲面指定をしない)
        /// [1]曲面タイプ１
        /// [2]曲面タイプ２
        /// [3]Catmull-Clark
        /// [4]OpenSubdiv
        /// </summary>
        public byte SurfaceSubdivision { get; set; }
        public bool CatmullClarkSubdivisionSettings { get; set; }
        /// <summary>
        /// 1～16
        /// </summary>
        public byte SubdivisionSegment { get; set; }
        public bool Visible { get; set; }
        public bool Locking { get; set; }
        public bool Shading { get; set; }
        /// <summary>
        /// 0～180
        /// </summary>
        public float Facet { get; set; }
        public RGBA Color { get; set; }
        public bool UseObjectColor { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]分離
        /// [2]接続
        /// </summary>
        public byte Mirror { get; set; }
        /// <summary>
        /// [1]X軸
        /// [2]Y軸
        /// [4]Z軸
        /// </summary>
        public byte MirrorAxis { get; set; }
        /// <summary>
        /// 0～
        /// </summary>
        public float MirrorDistance { get; set; }
        public bool Lathe { get; set; }
        /// <summary>
        /// [0]X軸
        /// [1]Y軸
        /// [2]Z軸
        /// </summary>
        public byte LatheAxis { get; set; }
        /// <summary>
        /// 3～
        /// </summary>
        public byte LatheSrgment { get; set; }
        public List<XYZ> Vertices { get; set; }
        public List<Face> Faces { get; set; }
    }

    /// <summary>
    /// RGBA色・透明度クラス
    /// 値域は0～1
    /// Aは不透明度のため 1:不透明 0:透明 となる
    /// </summary>
    public class RGBA
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public RGBA()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 1;
        }
        public RGBA(float red, float green, float blue, float alpha = 1)
        {
            R = red;
            G = green;
            B = blue;
            A = alpha;
        }

        /// <summary>
        /// HSVからRGBに変換して格納
        /// </summary>
        /// <param name="hue">色相：0～1</param>
        /// <param name="saturation">彩度：0～1</param>
        /// <param name="value">明度：0～1</param>
        /// <param name="alpha">不透明度：0～1（0で透明、1で不透明）</param>
        public void FromHSV(float hue, float saturation, float value, float alpha = 1)
        {

            A = alpha;

            //彩度が0の場合無彩色なので明度がそのままRGB値になる
            if (saturation == 0.0)
            {
                R = value;
                G = value;
                B = value;
                return;
            }

            //hueは角度のため、1.0と0.0は等しい
            if (hue == 1.0)
                hue = 0;

            float angle = hue * 6;
            float c = saturation * value;
            float x = c * (1 - Math.Abs(angle % 2 - 1));

            if (0 <= angle && angle < 1)
            {
                R = c;
                G = x;
                B = 0;
            }
            if (1 <= angle && angle < 2)
            {
                R = x;
                G = c;
                B = 0;
            }
            if (2 <= angle && angle < 3)
            {
                R = 0;
                G = c;
                B = x;
            }
            if (3 <= angle && angle < 4)
            {
                R = 0;
                G = x;
                B = c;
            }
            if (4 <= angle && angle < 5)
            {
                R = x;
                G = 0;
                B = c;
            }
            if (5 <= angle && angle < 6)
            {
                R = c;
                G = 0;
                B = x;
            }

            float m = value - c;
            R += m;
            G += m;
            B += m;
        }
    }

    public class XYZ
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public XYZ()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public XYZ(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class UV
    {
        public float U { get; set; }
        public float V { get; set; }

        public UV()
        {
            U = 0;
            V = 0;
        }
        public UV(float u, float v)
        {
            U = u;
            V = v;
        }
    }

    public class Face
    {
        public byte VertexNum { get; private set; }
        public List<int> VertexIndices
        {
            get => VertexIndices;
            set
            {
                VertexIndices = value;
                VertexNum = (byte)value.Count;
            }
        }
        public int MaterialID { get; set; }
        public List<UV> VertexUVs { get; set; }
        public List<RGBA> VertexColors { get; set; }
        public List<bool> CRS { get; set; }
    }
}
