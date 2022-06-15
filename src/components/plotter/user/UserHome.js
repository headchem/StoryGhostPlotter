import React, { useState, useEffect } from 'react'
import { toast } from 'react-toastify';
import { Link, useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import DeletePlot from './DeletePlot'

const UserHome = ({ userInfo }) => {

    const [plotsLoading, setPlotsLoading] = useState(false)
    const [userPlots, setUserPlots] = useState([])
    const [newPlotName, setNewPlotName] = useState('')
    const [newPlotLoading, setNewPlotLoading] = useState(false)
    const navigate = useNavigate()

    const toastSaveId = 'load-user-status'

    const notify = (msg) => {
        toast(msg, {
            toastId: toastSaveId,
            type: toast.TYPE.ERROR,
            autoClose: false
        });
    }

    const loadAllPlots = () => {
        setPlotsLoading(true)

        const loadPlots = async () => {

            fetch('/api/User').then(function (response) {
                if (response.status === 401 || response.status === 403) {
                    window.location.reload();
                } else {
                    if (response.ok) {
                        return response.json();
                    }
                }
                return Promise.reject(response);
            }).then(function (data) {
                if (data['plotReferences'] === null) {
                    setUserPlots([])
                } else {
                    setUserPlots(data['plotReferences'])
                }
            }).catch(function (error) {
                console.warn(error);
                notify('unable to communicate with server!')
            }).finally(function () {
                setPlotsLoading(false)
            });
        }

        loadPlots();
    }

    useEffect(() => {
        loadAllPlots()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const plotList = userPlots.map((plot) =>
        <div className='row user-plot-row p-3' key={plot['plotId']}>
            <div className='col-8'>
                <Link className="nav-link" to={'/plot?id=' + plot['plotId']}>{plot['displayName']}</Link>
            </div>
            <div className='col-4'>
                <DeletePlot plotId={plot['plotId']} plotTitle={plot['displayName']} loadAllPlots={loadAllPlots} />
            </div>
        </div>
    );

    const onCreateNewPlot = async () => {
        setNewPlotLoading(true)

        fetch('/api/NewPlot', {
            method: 'POST',
            body: newPlotName
        })
            .then(response => response.text())
            .then(newPlotId => {
                navigate('/plot?id=' + newPlotId)
            })
            .catch(error => {
                console.error(error)
            }).finally(function () {

            });

    }

    return (
        <div>
            {
                plotsLoading === true &&
                <Spinner animation="border" variant="secondary" />
            }
            {
                plotsLoading === false &&
                <>
                    {
                        plotList.length > 0 &&
                        <>
                            {plotList}
                        </>
                    }
                </>
            }

            <div className='row m-3'>
                <div className='col-6'>
                    <input
                        className='fs-5 form-control'
                        onChange={e => setNewPlotName(e.target.value)}
                        value={newPlotName}
                        placeholder='New plot name...'
                    />
                </div>
                <div className='col-6'>
                    <button disabled={newPlotLoading} onClick={onCreateNewPlot} type="button" className="btn btn-primary" >
                        {
                            newPlotLoading === true &&
                            <Spinner size="sm" as="span" animation="border" variant="dark" />
                        }
                        <span> Create new plot</span>
                    </button>
                </div>
            </div>

        </div>
    )
}

export default UserHome