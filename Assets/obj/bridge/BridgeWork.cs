using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BridgeWork : MonoBehaviour
{

    //�@�J�������ɂ��邩�ǂ���
    private bool isInsideCamera;

    //��x��ꂽ��
    private bool isOneBreak;
    //���ɖ߂�����
    private bool isRepair;
    //�\���A��\������
    private bool inVisible;
   
    [SerializeField]
    private List<Transform> targetPoints;

    protected BoxCollider boxCollider;

    protected List<Rigidbody> separateBlocks;

    public int FallTime;

    private int FallTimeBase;

    BackData[] pos_data;     //�ʒu���L�^�p

    Vector3[] start_pos;

    // Start is called before the first frame update
    void Start()
    {
        isInsideCamera =
            isRepair =
            inVisible =
            isOneBreak = false;

        FallTimeBase = FallTime;

        pos_data = new BackData[targetPoints.Count];
        start_pos = new Vector3[targetPoints.Count];
        for (int i = 0; i < targetPoints.Count; i++)
        {
            pos_data[i] = new BackData();
            pos_data[i].Init();
        }
        //�ŏ��̃|�W�V�������i�[���Ă���
        int i1 = 0;
        foreach (var targetPoint in targetPoints)
        {

            start_pos[i1] = targetPoint.position;
        }

            boxCollider = GetComponent<BoxCollider>();

        separateBlocks = GetComponentsInChildren<Rigidbody>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //���Ă��Ȃ��Ƃ�
        if (!isOneBreak)
        {
          
            //�J�����ɓ����Ă��Ȃ��Ƃ�
            if (!isInsideCamera)
            {
                CameraInObject();
            }
            //�J�����ɓ�������
            else
            {
                var min = -5;
                var max = 5;

                FallTime--;
                switch (TimeManager.state)
                {
                    case TimeManager.TimeState.TIME_BACK:
                        //����̂��I���ɂ���
                        isOneBreak = true;

                        //�S�Ă̎q�I�u�W�F�N�g�̕���������Ȃ���
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = true;

                            var vect = new Vector3(0, 0, 0);
                            r.AddForce(vect, ForceMode.Impulse);
                        });
                        break;

                    case TimeManager.TimeState.TIME_FAST:
                        
                        var random = new System.Random();

                        //�S�Ă̎q�I�u�W�F�N�g�𓮂���
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = false;

                            var vect = new Vector3(random.Next(min, max) / 10.0f, random.Next(min, max) / 10.0f, random.Next(min, max) / 10.0f);
                            r.AddForce(vect, ForceMode.Impulse);
                        });

                        //�S�Ă̎q�I�u�W�F�N�g�̍��W�f�[�^�ۑ�
                        int cf = 0;
                        targetPoints.ForEach(t =>
                        {

                            pos_data[cf].AddData(t.position);
                            cf++;

                        });
                        

                        break;

                    case TimeManager.TimeState.TIME_PLAY:
           
                        var random1 = new System.Random();
                        //�S�Ă̎q�I�u�W�F�N�g�𓮂���
                        separateBlocks.ForEach(r =>
                        {
                            r.isKinematic = false;

                            var vect = new Vector3(random1.Next(min, max) / 10.0f, random1.Next(min, max) / 10.0f, random1.Next(min, max) / 10.0f);
                            r.AddForce(vect, ForceMode.Impulse);
                        });


                        //�S�Ă̎q�I�u�W�F�N�g�̍��W�f�[�^�ۑ�
                        int cp = 0;
                        targetPoints.ForEach(t =>
                        {

                            pos_data[cp].AddData(t.position);
                            cp++;

                        });

                        break;

                    case TimeManager.TimeState.TIME_STOP:
                        break;
                }
                if(FallTime < 0)
                {
                    //��\���ɂ���
                    targetPoints.ForEach(t =>
                    {
                        t.gameObject.SetActive(false);
                    });

                    //����������Ȃ���
                    separateBlocks.ForEach(r =>
                    {
                        r.isKinematic = true;

                        var vect = new Vector3(0, 0, 0);
                        r.AddForce(vect, ForceMode.Impulse);
                    });

                    isOneBreak = true;
                    inVisible = true;
                    FallTime = FallTimeBase;
                }

            }
        }
        //��ꂽ�Ƃ�
        else
        {
            //����܂�
            if(!isRepair)
            {
                switch (TimeManager.state)
                {
                    case TimeManager.TimeState.TIME_BACK:
                        //������悤�ɂ���
                        if(inVisible)
                        {
                            inVisible = false;
                            targetPoints.ForEach(t =>
                            {
                                t.gameObject.SetActive(true);
                            });

                        }
                        //���ɖ߂�
                        int cb = 0;
                        targetPoints.ForEach(t =>
                        {
                            t.position = pos_data[cb].DataBack();
                            cb++;
                        });

                        
                        int i2 = 0;
                        foreach (var targetPoint in targetPoints)
                        {
                            //���ɖ߂���
                            if (start_pos[i2] == targetPoint.position)
                            {
                                isRepair = true;
                                boxCollider.enabled = true;
                            }
                            
                        }


                        break;

                    case TimeManager.TimeState.TIME_FAST:

                        break;

                    case TimeManager.TimeState.TIME_PLAY:

                        break;

                    case TimeManager.TimeState.TIME_STOP:
                        break;
                }
            }
           
        }

        

    }
    //�J�������ɂ��邩���Ȃ������肷��
    private void CameraInObject()
    {
        int count = 0;

        //�@�J�����̃r���[�|�[�g�ʒu
        Vector2 viewportPoint;

        //�@�^�[�Q�b�g�|�C���g���J�����̃r���[�|�[�g���ɂ��邩�ǂ����𒲂ׂ�
        foreach (var targetPoint in targetPoints)
        {
            //�@�r���[�|�[�g�̌v�Z
            viewportPoint = Camera.main.WorldToViewportPoint(targetPoint.position);

            if (0f <= viewportPoint.x && viewportPoint.x <= 1f
                && 0f <= viewportPoint.y && viewportPoint.y <= 1f
                )
            {
                count++;              
            }
            else
            { 
                break;
            }
        }

        if (count == targetPoints.Count)
        {

            isInsideCamera = true;
            boxCollider.enabled = false;

        }


    }

}
