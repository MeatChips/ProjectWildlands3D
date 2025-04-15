Shader "Custom/InteractionCircle"
{
    Properties
    {
        _Color("Color", Color) = (0, 1, 1, 1) // The color of the circle
        _Radius("Radius", Float) = 0.5 // The radius of the circle
        _Thickness("Thickness", Float) = 0.05 // The thickness of the circle
    }
    SubShader
    {
        // This tells Unity that the shader is transparent
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100 // level of detail

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off

            CGPROGRAM
            // This tells Unity which functions to use for the vertex and fragment shader.
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" // Include unity shader functions

            // The variables we defined at the start of the shader
            fixed4 _Color;
            float _Radius;
            float _Thickness;

            // This is the input for each vertex of the mesh
            struct appdata
            {
                float4 vertex : POSITION; // Position of vertex
                float2 uv : TEXCOORD0; // UV coordinates, this is used to figure out where on the texture we are
            };

            // This is what gets passed from the vertex shader to the fragment shader
            struct v2f
            {
                float2 uv : TEXCOORD0; // UV coordinates that we modified
                float4 vertex : SV_POSITION; // Final position on the screen
            };

            // This is the vertex shader
            v2f vert(appdata v)
            {
                v2f o;
                // Converts the 3D position to 2D screen space so Unity knows where to draw it
                o.vertex = UnityObjectToClipPos(v.vertex);

                // UVs usually go from 0 to 1. This turns them into -1 to 1 so the center is (0,0)
                o.uv = v.uv * 2.0 - 1.0;
                return o;
            }

            // This is the fragment shader
            fixed4 frag(v2f i) : SV_Target
            {
                // Calculate how far we are from the center (0,0)
                float dist = length(i.uv);

                // Inner and outer edges of the ring
                float inner = _Radius - _Thickness * 0.5;
                float outer = _Radius + _Thickness * 0.5;

                // Create a smooth fade-in at the inner edge and a fade-out at the outer edge
                float ring = smoothstep(inner, inner + 0.01, dist) * 
                             (1.0 - smoothstep(outer - 0.01, outer, dist));

                // Final color
                return fixed4(_Color.rgb, ring * _Color.a);
            }
            ENDCG
        }
    }
}