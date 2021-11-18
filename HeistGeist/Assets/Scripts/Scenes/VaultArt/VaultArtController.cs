using Keypad;
using Scenes.VaultArt.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.VaultArt
{
    public class VaultArtController : GameplaySceneController
    {
        [SerializeField] private PaintingFrameData[] roomAPaintings = new PaintingFrameData[4];
        [SerializeField] private PaintingFrameData[] roomBPaintings = new PaintingFrameData[4];
        [SerializeField] private PaintingFrameData[] roomCPaintings = new PaintingFrameData[4];
        [SerializeField] private PaintingFrameData[] roomDPaintings = new PaintingFrameData[4];
        private PaintingFrameData[][] _allRooms = new PaintingFrameData[4][]; //for the Inspector purpose there are 4 arrays, but this is needed
        [SerializeField] private PaintingFrameData[] genericPaintings;

        [SerializeField] private PaintingFrame[] frames;
        [SerializeField] private int[] doorCode = new int[4];
        [SerializeField] private UIKeypad uiKeypad;
        
        [SerializeField] private Sprite[] numbersSprites;

        protected void Awake()
        {
            _allRooms = new PaintingFrameData[][]
            {
                roomAPaintings,
                roomBPaintings,
                roomCPaintings,
                roomDPaintings
            };
        }

        protected void Start()
        {   /*
            PaintingFrame currentFrame = frames[0];
            PaintingFrameData paintingData = roomAPaintings[1];
            currentFrame.SetPaintingFrameData(paintingData);
            currentFrame.SetCodeNumber(numbersSprites[1]);
            */
            Generate();
        }

        protected override void Generate()
        {
            //Generate a random door code
            for (int i = 0; i < doorCode.Length; i++)
                doorCode[i] = Random.Range(0, 10);

            uiKeypad.SetCode(doorCode);
                
            //Choose a room
            PaintingFrameData[] chosenRoom = _allRooms[Random.Range(0,4)];
            
            //
            int[] framesIndexes = new int[frames.Length];
            for (int i = 0; i < framesIndexes.Length; i++)
            {
                framesIndexes[i] = i;
            }
            //Random permutation of indexes
            for (int i = 0; i < framesIndexes.Length; i++)
            {
                int swapWith = Random.Range(0, framesIndexes.Length);
                (framesIndexes[swapWith], framesIndexes[i]) = (framesIndexes[i], framesIndexes[swapWith]);
            }
            //Assign paintings to frames
            int j = 0;
            foreach (PaintingFrameData paintingData in chosenRoom)
            {
                PaintingFrame currentFrame = frames[framesIndexes[j]];
                int currentCodeDigit = doorCode[j];
                
                currentFrame.SetPaintingFrameData(paintingData);
                currentFrame.SetCodeNumber(numbersSprites[currentCodeDigit]);
                j++;
            }
            for (; j < framesIndexes.Length; j++)
            {
                PaintingFrame currentFrame = frames[framesIndexes[j]];
                PaintingFrameData randomGenericPaintingData = 
                    genericPaintings[Random.Range(0,genericPaintings.Length)];
                Sprite randomNumberSprite = numbersSprites[Random.Range(0, 10)];
                
                currentFrame.SetPaintingFrameData(randomGenericPaintingData);
                currentFrame.SetCodeNumber(randomNumberSprite);
            }
        }
    }
}