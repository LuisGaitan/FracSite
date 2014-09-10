Shader "Custom/Blend 2 Textures + Alpha" {
	Properties {
		_Color ("Color Tint (A = Opacity)", Color) = (1,1,1,1)
		_Blend ("Blend", Range (0,1)) = 0.0
		_MainTexture1 ("Texture1", 2D) = ""
		_MainTexture2 ("Texture2", 2D) = ""
		_Mask ("Culling Mask", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range (0,1)) = 0.0
	}
	
	Category {
		Material {
			Ambient[_Color]
			Diffuse[_Color]
		}
		
		SubShader {
			Tags {"Queue" = "Transparent"}
			ZWrite Off
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha
			AlphaTest GEqual [_Cutoff]
		
			Pass {
				Lighting On
			
				SetTexture[_MainTexture1]
				SetTexture[_MainTexture2] {
					ConstantColor (0,0,0, [_Blend])
					Combine texture Lerp(constant) previous
				}
				
				SetTexture [_Mask] {combine texture * previous}
				SetTexture[_Color] {Combine previous * constant ConstantColor[_Color]}
			}
		}
	}
}