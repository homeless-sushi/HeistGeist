using Scenes.VaultArt.Data;
using Scenes.VaultArt.UI;
using UnityEngine;

namespace Scenes.VaultArt
{
    public class PaintingFrame : MonoBehaviour
    {
        private SpriteRenderer _paintingSpriteRenderer; //SpriteRenderer for the painting
        [SerializeField] private SpriteRenderer frameSpriteRenderer; //SpriteRenderer for the frame
        
        [SerializeField] private PaintingFrameData paintingFrameData; //Data with the painting's sprite
        [SerializeField] private Sprite codeNumber; //Sprite of the code number

        [SerializeField] private UIInspectPainting uIInspectPainting; //Component that controls the UI
        
        private void Awake()
        {
            _paintingSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void SetPaintingFrameData(PaintingFrameData paintingFrameData)
        {
            this.paintingFrameData = paintingFrameData;
            _paintingSpriteRenderer.sprite = this.paintingFrameData.Painting;
            frameSpriteRenderer.sprite = this.paintingFrameData.FrameData.Frame;
        }
        
        public void SetCodeNumber(Sprite codeNumber)
        {
            this.codeNumber = codeNumber;
        }

        public void InspectPainting()
        {
            if (paintingFrameData == null)
                return;
            
            uIInspectPainting.SetFrame(paintingFrameData.FrameData.UIFrame);
            uIInspectPainting.SetPainting(paintingFrameData.UIPainting);
            uIInspectPainting.SetCodeNumber(codeNumber);
            uIInspectPainting.Display();
        }

        public void CloseInspectPainting()
        {
            uIInspectPainting.Close();
        }
    }
}