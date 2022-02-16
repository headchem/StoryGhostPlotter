import React, { useState, useEffect } from 'react'
import { Link, useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import DeletePlot from './DeletePlot'

const UserHome = ({ userInfo }) => {

    const [plotsLoading, setPlotsLoading] = useState(false)
    const [userPlots, setUserPlots] = useState([])
    const [newPlotName, setNewPlotName] = useState('')
    const [newPlotLoading, setNewPlotLoading] = useState(false)
    const navigate = useNavigate()

    const loadAllPlots = () => {
        setPlotsLoading(true)

        const loadPlots = async () => {

            fetch('/api/User').then(function (response) {
                if (response.ok) {
                    return response.json();
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
        // NewPlot


        fetch('/api/NewPlot', {
            method: 'POST',
            body: newPlotName
        })
            .then(response => response.text())
            .then(newPlotId => {
                //console.log('redirect to plot?id=' + newPlotId);
                navigate('/plot?id=' + newPlotId)
            })
            .catch(error => {
                console.error(error)
            }).finally(function () {

            });

    }

    return (
        <div>
            <p>User home goes here</p>

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
                    {
                        plotList.length === 0 &&
                        <p>No plots have been created yet.</p>
                    }
                </>
            }
            {
                newPlotLoading &&
                <>
                    <p>creating new plot...</p>
                </>
            }
            {
                newPlotLoading === false &&
                <>
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
                            <button onClick={onCreateNewPlot} type="button" className="btn btn-primary" >
                                Create new plot
                            </button>
                        </div>
                    </div>
                </>
            }
        </div>
    )
}

export default UserHome